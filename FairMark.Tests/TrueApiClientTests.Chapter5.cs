using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FairMark.TrueApi.DataContracts;
using NUnit.Framework;

namespace FairMark.TrueApi.Tests
{
    [TestFixture]
    public partial class TrueApiClientTests : UnitTestsBase
    {
        [Test]
        public void Chapter_5_1_2_GetCisesByOrderId()
        {
            var verificationCises = new[]
            {
                "0104635785586010215MRZpi",
                "0104635785586010215O(JSD",
                "0104635785586010215boSWI",
                "0104635785586010215Yc51t",
                "0104635785586010215cS2kT",
                "0104635785586010215kyoYo",
                "0104635785586010215S4PPf",
                "0104635785586010215BC!FF",
                "0104635785586010215UrkP'",
                "0104635785586010215nU:VT"
            };

            var cises = Client.GetCisesByOrderId("a1769132-796e-47cb-8bc5-1053c4d7d6c5");
            Assert.NotNull(cises);
            CollectionAssert.AreEquivalent(verificationCises, cises);
        }
    }
}
