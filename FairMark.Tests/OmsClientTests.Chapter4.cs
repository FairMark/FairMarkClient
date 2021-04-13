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
            var order = new Order
            {
                Products = new List<OrderProduct>
                {
                    new OrderProduct
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
                }
            };
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
