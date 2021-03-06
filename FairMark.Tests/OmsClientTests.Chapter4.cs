using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FairMark.OmsApi;
using FairMark.OmsApi.DataContracts;
using NUnit.Framework;

namespace FairMark.Tests
{
    [TestFixture]
    public partial class OmsClientTests : UnitTestsBase
    {
        private OmsApiClient Client { get; } = new OmsApiClient(OmsApiClient.SandboxApiUrl, OmsApiClient.SandboxAuthUrl, ProductGroupsOMS.milk, new OmsCredentials
        {
            CertificateThumbprint = TestCertificateThumbprint,
            OmsID = TestOmsID, // it's case sensitive, to my surprise
            OmsConnectionID = TestOmsConnectionID,

            // SessionToken is not required in production code
            // it is used here to skip authentication in unit tests
            SessionToken = LoadOmsApiToken(),
        })
        {
            Tracer = TestContext.Progress.WriteLine,
        };

        public OmsClientTests()
        {
            // enforce authentication and make sure 
            // that the last OMS auth token is saved
            Client.Ping();
            SaveOmsApiToken(Client.Authenticator.AuthToken);
        }

        [Test]
        public void Chapter_4_5_1_CreateOrder_FailsOnInvalidData()
        {
            var ex = Assert.Throws<FairMarkException>(() =>
            {
                Client.CreateOrder(new Order_Milk());
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.IsNotNull(ex.ErrorResponse);
            Assert.IsFalse(ex.ErrorResponse.Success);
            Assert.IsNotNull(ex.ErrorResponse.FieldErrors);
            Assert.IsTrue(ex.ErrorResponse.FieldErrors.Count > 0);
        }

        [Test, Explicit("OMS API has restrictions on emission orders")]
        public void Chapter_4_5_1_CreateOrder()
        {
            var order = new Order_Milk
            {
                Products = new List<OrderProduct_Milk>
                {
                    new OrderProduct_Milk
                    {
                        Gtin = "04635785586010",
                        Quantity = 5,
                        SerialNumberType = SerialNumberTypes.SELF_MADE,
                        SerialNumbers = new List<string>
                        {
                            "asde5", "asde6", "asde7", "asde8", "asde9"
                        },
                        TemplateID = Templates.T20,
                        StickerID = 19, // or is it a string?
                    },
                },
                ContactPerson = "Говоров К.А.",
                ReleaseMethodType = ReleaseMethodTypes.PRODUCTION,
                ProductionOrderID = "efa002c4-aaf1-4862-93c8-823b7e7468ad",

                // пример для самостоятельного производства
                CreateMethodType = CreateMethodTypes.SELF_MADE,

                // пример для контрактного производства: надо указать ServiceProviderID
                //CreateMethodType = CreateMethodTypes.CM,
                //ServiceProviderID = "156893d9-42d9-4753-9a19-bdbf182c7851",
            };

            // Unsigned order placed: 9d420e24-38ea-401c-bf5b-4947bf25384b
            // Signed order placed: 836cc65b-6b89-40f2-b074-0bcd22b998cd
            // Signed order placed: d2cfbb03-0ac1-498e-b1be-7918f49e45e6
            // Signed order placed: d22797da-b3ae-4607-9170-22cd1da81806
            // Signed order placed: e76518d3-213a-477a-959d-d9962fc6d00d
            // Expected to be ready in: 120000
            var res = Client.CreateOrder(order);
            TestContext.Progress.WriteLine($"Signed order placed: {res.OrderID}");
            TestContext.Progress.WriteLine($"Expected to be ready in: {res.ExpectedCompleteTimestamp}");
        }

        [Test]
        public void Chapter_4_5_2_Dropout_EmptyReportNotAllowed()
        {
            var ex = Assert.Throws<FairMarkException>(() =>
            {
                Client.Dropout(new DropoutReport
                {
                    DropoutReason = DropoutReasons.OTHER,
                });
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.IsNotNull(ex.ErrorResponse);
            Assert.IsFalse(ex.ErrorResponse.Success);
            Assert.IsNotNull(ex.ErrorResponse.FieldErrors);
            Assert.IsTrue(ex.ErrorResponse.FieldErrors.Count > 0);
        }

        [Test, Explicit("You can drop out a CIS code only once")]
        public void Chapter_4_5_2_Dropout()
        {
            // порядок действий для обновления теста:
            // 1. оформить заказ на коды маркировки, см. Chapter_4_5_1_CreateOrder
            // 2. получить из заказа коды маркировки, см. Chapter_4_5_6_GetCodes
            // 3. вставить код маркировки в этот тест
            // 4. выполнить тест, сохранить полученный код отчета
            var reportId = Client.Dropout(new DropoutReport
            {
                DropoutReason = DropoutReasons.CONFISCATION,
                Sntins = new List<string>
                {
                    "0104635785586010215asde0\u001D93dGVz",
                }
            });

            Assert.IsNotNull(reportId);
            TestContext.Progress.WriteLine($"Dropout report: {reportId}");
        }

        [Test]
        public void Chapter_4_5_5_CloseOrder_Invalid()
        {
            // Signed order placed: d2cfbb03-0ac1-498e-b1be-7918f49e45e6
            var ex = Assert.Throws<FairMarkException>(() =>
                Client.CloseOrder("836cc65b-6b89-40f2-b074-0bcd22b998cd"));

            Assert.NotNull(ex.ErrorResponse);
            Assert.IsFalse(ex.ErrorResponse.Success);
            Assert.NotNull(ex.ErrorResponse.GlobalErrors);
            Assert.IsTrue(ex.ErrorResponse.GlobalErrors.Count > 0);
            Assert.IsTrue(ex.ErrorResponse.GlobalErrors.Count > 0);
            Assert.AreEqual(3370, ex.ErrorResponse.GlobalErrors.First().ErrorCode);
        }

        [Test, Explicit("An order can be closed only once")]
        public void Chapter_4_5_5_CloseOrder_Valid()
        {
            // чтобы выполнить этот тест, надо создать новый заказ и прописать его код
            var omsId = Client.CloseOrder("d22797da-b3ae-4607-9170-22cd1da81806"); //  "d2cfbb03 -0ac1-498e-b1be-7918f49e45e6");
            Assert.AreEqual(Client.OmsCredentials.OmsID, omsId);
        }

        [Test]
        public void Chapter_4_5_6_GetCodes_InvalidOrder()
        {
            var ex = Assert.Throws<FairMarkException>(() =>
            {
                var orderId = "836cc65b-6b89-40f2-b074-0bcd22b998cd";
                var gtin = "04635785586010";
                Client.GetCodes(orderId, gtin, 1000);
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.NotNull(ex.ErrorResponse);
            Assert.NotNull(ex.ErrorResponse.GlobalErrors);
            Assert.IsTrue(ex.ErrorResponse.GlobalErrors.Count > 0);
        }

        [Test, Explicit("GetCodes works only once for each order")]
        public void Chapter_4_5_6_GetCodes()
        {
            // реквизиты заказа, из которого мы выкачиваем коды
            var orderId = "e76518d3-213a-477a-959d-d9962fc6d00d";
            var gtin = "04635785586010";
            var blockSize = 2;
            var lastBlockId = default(string);

            // получим состояние буфера кодов по данному товару, убедимся, что он активен
            var blockStatus = Client.GetBufferStatus(orderId, gtin);
            Assert.AreEqual(BufferStatuses.ACTIVE, blockStatus.BufferStatus);

            // определим, сколько всего по данному товару осталось кодов
            var totalQuantity = blockStatus.AvailableCodes;
            blockSize = Math.Min(blockSize, totalQuantity);

            // выкачиваем блоками все коды без остатка
            while (totalQuantity > 0)
            {
                var codes = Client.GetCodes(orderId, gtin, blockSize, lastBlockId);
                Assert.NotNull(codes);
                Assert.NotNull(codes.Codes);
                Assert.AreEqual(Client.OmsCredentials.OmsID, codes.OmsID);
                lastBlockId = codes.BlockID;

                // запрашивать можно не больше, чем осталось в буфере
                totalQuantity -= blockSize;
                blockSize = Math.Min(blockSize, totalQuantity);

                // остановиться после первого блока,
                // если нужно поэкспериментировать с частично
                // выполненным заказом:
                // break;
            }
        }

        [Test]
        public void Chapter_4_5_7_GetBufferStatus_Invalid()
        {
            // invalid order/gtin
            var ex = Assert.Throws<FairMarkException>(() =>
            {
                Client.GetBufferStatus("unexisting-order-id", "invalid-gtin");
            });

            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.NotNull(ex.Message);

            // valid order/gtin: already closed
            ex = Assert.Throws<FairMarkException>(() =>
            {
                var signedOrderId = "836cc65b-6b89-40f2-b074-0bcd22b998cd";
                var milkGtin = "04635785586010";
                var buffer = Client.GetBufferStatus(signedOrderId, milkGtin);
                Assert.NotNull(buffer);
                Assert.AreEqual(BufferStatuses.CLOSED, buffer.BufferStatus);
            });
        }

        [Test, Explicit("This data becomes obsolete once the order gets closed")]
        public void Chapter_4_5_7_GetBufferStatus_RejectedAsDuplicates()
        {
            // valid order/gtin: rejected 
            var signedOrderId = "d2cfbb03-0ac1-498e-b1be-7918f49e45e6";
            var milkGtin = "04635785586010";
            var buffer = Client.GetBufferStatus(signedOrderId, milkGtin);
            Assert.NotNull(buffer);
            Assert.AreEqual(BufferStatuses.REJECTED, buffer.BufferStatus);
        }

        [Test]
        public void Chapter_4_5_8_GetOrders()
        {
            // В документации говорится: использование предоставляемых этим методом
            // возможностей в штатных процессах работы с СУЗ запрещено.
            // Видимо, имеется в виду, что часто его вызывать нельзя.
            var orders = Client.GetOrders();
            Assert.IsNotNull(orders);
            Assert.IsNotNull(orders.OrderInfos);
        }

        [Test]
        public void Chapter_4_5_9_GetAggregationInfo()
        {
            // invalid serial number
            var ex = Assert.Throws<FairMarkException>(() =>
                Client.GetAggregationInfo("0100000000777999213l1SMYX8005100000"));

            Assert.AreEqual(HttpStatusCode.BadRequest, ex.StatusCode);
            Assert.IsNotNull(ex.ErrorResponse);
            Assert.IsNotNull(ex.ErrorResponse.GlobalErrors);
            Assert.IsTrue(ex.ErrorResponse.GlobalErrors.Count > 0);
            Assert.AreEqual(7270, ex.ErrorResponse.GlobalErrors.First().ErrorCode);

            // TODO: find a valid serial number
            ////var info = Client.GetAggregationInfo("0100000000777999213l1SMYX8005100000");
            ////Assert.IsNotNull(info);
            ////Assert.IsNotNull(info.AggregationUnit);
        }

        [Test]
        public void Chapter_4_5_10_GetReportStatus()
        {
            // порядок обновления теста:
            // 1. обновить и выполнить тест Chapter_4_5_2_Dropout
            // 2. вставить в этот тест код отчета, полученый в п.1
            var status = Client.GetReportStatus("e684142c-ff5e-492c-9864-c9c41a26cb7e"); // "50a2d2a9-c508-4066-bc75-2f9568850e39");
            Assert.NotNull(status);
            Assert.AreEqual(TestOmsID, status.OmsID);
            Assert.AreEqual(ReportStatuses.SENT, status.ReportStatus);
            Assert.IsNull(status.ErrorReason);
        }

        [Test]
        public void Chapter_4_5_11_Ping()
        {
            var omsId = Client.Ping();
            Assert.NotNull(omsId);
            Assert.AreEqual(omsId, TestOmsID);
        }

        [Test]
        public void Chapter_4_5_13_GetVersion()
        {
            var version = Client.GetVersion();
            Assert.NotNull(version);
            Assert.NotNull(version.ApiVersion);
            Assert.NotNull(version.OmsVersion);
        }

        [Test, Explicit("This data becomes obsolete once the order gets closed")]
        public void Chapter_4_5_14_GetCodeBlocks()
        {
            // чтобы обновить этот тест, надо
            // 1. оформить новый заказ, см. метод Chapter_4_5_1_CreateOrder
            // 2. запросить блок кодов, см. метод Chapter_4_5_6_GetCodes, но до конца все коды не запрашивать
            // 3. вставить в текст код недозапрошенного заказа
            var signedOrderId = "e76518d3-213a-477a-959d-d9962fc6d00d";
            var milkGtin = "04635785586010";
            var blocks = Client.GetCodeBlocks(signedOrderId, milkGtin);
            Assert.NotNull(blocks);
            Assert.NotNull(blocks.Blocks);
        }

        [Test, Explicit("This data becomes obsolete once the order gets closed")]
        public void Chapter_4_5_15_RetryCodes()
        {
            // чтобы обновить этот тест, надо
            // 1. получить какой-нибудь код блока, см. метод Chapter_4_5_14_GetCodeBlocks
            // 2. вставить в текст код любого уже запрошенного блока
            var signedOrderId = "e76518d3-213a-477a-959d-d9962fc6d00d";
            var milkGtin = "04635785586010";
            var blockId = "b573db0b-1b40-4878-86f2-e7e95b2afbc8";
            var codes = Client.RetryCodes(signedOrderId, milkGtin, blockId);
            Assert.NotNull(codes);
            Assert.NotNull(codes.Codes);
        }

        [Test, Explicit("Fails to work, seems like temporary OMS API issues")]
        public void Chapter_4_5_16_GetReceipts()
        {
            // возьмем первый попавшийся активный документ
            var orders = Client.GetOrders();
            var firstOrderId = orders.OrderInfos.First().OrderID;
            //var firstOrderId = "e76518d3-213a-477a-959d-d9962fc6d00d";

            var receipts = Client.GetReceipts(firstOrderId.ToString());
            Assert.NotNull(receipts);
            Assert.NotNull(receipts.Receipts);
            Assert.NotNull(receipts.Receipts.First());
        }

        [Test]
        public void Chapter_4_5_17_GetServiceProviders()
        {
            var providers = Client.GetServiceProviders();
            Assert.NotNull(providers);
            Assert.NotNull(providers.Providers);
            Assert.NotNull(providers.Providers.First());
        }
    }
}
