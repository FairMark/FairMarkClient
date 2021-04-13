using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairMark.OmsApi;
using FairMark.OmsApi.DataContracts;
using FairMark.OmsApi.Dictionaries;
using NUnit.Framework;

namespace FairMark.TrueApi.Tests
{
    [TestFixture]
    public partial class OmsClientTests : UnitTestsBase
    {
        private OmsApiClient Client { get; } = new OmsApiClient(OmsApiClient.SandboxApiUrl, OmsApiClient.SandboxAuthUrl, "milk", new OmsCredentials
        {
            CertificateThumbprint = TestCertificateThumbprint,
            OmsID = TestOmsID, // it's case sensitive, to my surprise
            OmsConnectionID = TestOmsConnectionID,
        })
        {
            Tracer = TestContext.Progress.WriteLine,
        };

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
                            "asdf7", "asdf8", "asdf9", "asdfa", "asdfb"
                        },
                        TemplateID = 20,
                        StickerID = "19", // is it a string?
                    },
                },
                ContactPerson = "Говоров К.А.",
                ReleaseMethodType = ReleaseMethodTypes.PRODUCTION,
                CreateMethodType = CreateMethodTypes.CM,
                ServiceProviderID = "156893d9-42d9-4753-9a19-bdbf182c7851",
                ProductionOrderID = "efa002c4-aaf1-4862-93c8-823b7e7468ad",
            };

            // Order placed: 9d420e24-38ea-401c-bf5b-4947bf25384b
            // Expected to be ready in: 120000
            var res = Client.CreateOrder(order);
            TestContext.Progress.WriteLine($"Order placed: {res.OrderID}");
            TestContext.Progress.WriteLine($"Expected to be ready in: {res.ExpectedCompleteTimestamp}");
        }

        [Test]
        public void Chapter_4_5_8_GetOrderSummaries()
        {
            var summaries = Client.GetOrderSummaries();
            Assert.IsNotNull(summaries);
            Assert.IsNotNull(summaries.OrderInfos);
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
    }
}
