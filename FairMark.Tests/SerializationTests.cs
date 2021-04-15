using System;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.Serialization;
using FairMark.DataContracts;
using FairMark.Toolbox;
using NUnit.Framework;
using RestSharp;

namespace FairMark.Tests
{
    [TestFixture]
    public class SerializationTests : UnitTestsBase
    {
        private string Serialize<T>(T dto)
        {
            var ss = new ServiceStackSerializer();
            return ss.Serialize(dto);
        }

        private T Deserialize<T>(string json)
        {
            var ss = new ServiceStackSerializer();
            return ss.Deserialize<T>(json);
        }

        public enum FooBar
        {
            FOO = 0, BAR = 3,
            [EnumMember(Value = "QUUX")]
            QUUX = 4
        }

        [DataContract]
        public class FooBarHolder
        {
            [DataMember(Name = "waldo")]
            public FooBar Baz { get; set; }
        }

        [Test]
        public void EnumsSerializedByTheirMemberNames()
        {
            var src = new FooBarHolder { Baz = FooBar.QUUX };
            var ser = Serialize(src);
            Assert.NotNull(ser);
            Assert.AreEqual("{\"waldo\":\"QUUX\"}", ser);

            var deser = Deserialize<FooBarHolder>(ser);
            Assert.AreEqual(src.Baz, deser.Baz);

            src.Baz = (FooBar)3;
            ser = Serialize(src);
            Assert.NotNull(ser);
            Assert.AreEqual("{\"waldo\":\"BAR\"}", ser);
        }

        #region JSON иерархия — нет, такое мы использовать не будем:

        [DataContract]
        public class Base
        {
            [DataMember(Name = "sys_id")]
            public string SystemSubjectID { get; set; }

            [DataMember(Name = "name")]
            public string Name { get; set; }
        }

        [DataContract]
        public class Native : Base
        {
            [DataMember(Name = "inn")]
            public string Inn { get; set; }
        }

        [DataContract]
        public class Foreign : Base
        {
            [DataMember(Name = "itin")]
            public string Itin { get; set; }
        }

        [DataContract]
        public class Response
        {
            [DataMember(Name = "items")]
            public Base[] Items { get; set; }
        }

        [Test]
        public void JsonTest()
        {
            var r = new Response
            {
                Items = new Base[]
                {
                    new Base { SystemSubjectID = "1", Name = "Base1" },
                    new Native { SystemSubjectID = "2", Name = "Native2", Inn = "3121" },
                    new Foreign { SystemSubjectID = "3", Name = "Foreign3", Itin = "1231" },
                }
            };

            var json = Serialize(r);
            Assert.NotNull(json);
            WriteLine(JsonFormatter.FormatJson(json));

            var obj = Deserialize<Response>(json);
            Assert.NotNull(obj);
        }

        #endregion

        // А вот такое придется использовать для метода 8.4.3:

        [DataContract]
        public class SsccInfo
        {
            [DataMember(Name = "sscc")]
            public string Sscc { get; set; }

            [DataMember(Name = "childs")]
            public SsccOrSgtinInfo[] Children { get; set; }

            [IgnoreDataMember]
            public SsccInfo[] ChildSsccs { get; set; }

            [IgnoreDataMember]
            public SgtinInfo[] ChildSgtins { get; set; }
        }

        [DataContract]
        public class SsccOrSgtinInfo : SsccInfo
        {
            internal bool IsSgtinInfo => Sgtin != null || Gtin != null;

            internal SgtinInfo GetSgtinInfo => new SgtinInfo
            {
                Sscc = Sscc,
                Sgtin = Sgtin,
                Gtin = Gtin,
            };

            // a copy of distinct SgtinInfo members
            [DataMember(Name = "sgtin")]
            public string Sgtin { get; set; }

            [DataMember(Name = "gtin")]
            public string Gtin { get; set; }
        }

        [DataContract]
        public class SgtinInfo
        {
            [DataMember(Name = "sscc")]
            public string Sscc { get; set; }

            [DataMember(Name = "sgtin")]
            public string Sgtin { get; set; }

            [DataMember(Name = "gtin")]
            public string Gtin { get; set; }
        }

        [Test]
        public void PolymorphicCrapPrototypeForMethod843()
        {
            var shit = new SsccInfo
            {
                Sscc = "Root",
                Children = new[]
                {
                    new SsccOrSgtinInfo
                    {
                        Sscc = "Child",
                        Children = new[]
                        {
                            new SsccOrSgtinInfo
                            {
                                Sgtin = "ChildSgtin",
                                Sscc = "ChildSscc",
                                Gtin = "ChildGtin",
                            }
                        }
                    },
                    new SsccOrSgtinInfo
                    {
                        Sscc = "Child2",
                        Children = new[]
                        {
                            new SsccOrSgtinInfo
                            {
                                Sgtin = "Child2Sgtin",
                                Sscc = "Child2Sscc",
                                Gtin = "Child2Gtin",
                            }
                        }
                    }
                }
            };

            var json = Serialize(shit);
            Assert.NotNull(json);
            WriteLine(JsonFormatter.FormatJson(json));

            var obj = Deserialize<SsccInfo>(json);
            Assert.NotNull(obj);
        }

        [DataContract]
        public class CustomThing
        {
            [DataMember(Name = "from")]
            public CustomDateTime From { get; set; }
            [DataMember(Name = "to")]
            public CustomDateTime To { get; set; }
            [DataMember(Name = "now")]
            public CustomDateTime Now { get; set; }
            [DataMember(Name = "then")]
            public CustomDateTime Then { get; set; }
            [DataMember(Name = "start")]
            public CustomDateTimeSpace Start { get; set; }
            [DataMember(Name = "end")]
            public CustomDateTimeSpace End { get; set; }
        }

        // TODO: not implemented
        private void ExplicitConversions<T>(DateTime dateTime, string str)
        {
            // explicit conversion from date/time
            T dt = (T)(object)dateTime;

            // explicit conversion to string
            var s = (string)(object)dt;
            Assert.AreEqual(str, s);

            // explicit conversion from nullable date/time with value
            dt = (T)(object)new DateTime?(dateTime);
            s = (string)(object)dt;
            Assert.AreEqual(str, s);

            // explicit conversion from nullable date/time with no value
            dt = (T)(object)new DateTime?();
            s = (string)(object)dt;
            Assert.IsNull(s);

            // test explicit conversions:
            //ExplicitConversions<CustomDateTime>(new DateTime(2020, 04, 24, 1, 2, 3), "2020-04-24T01:02:03Z");
            //ExplicitConversions<CustomDate>(new DateTime(2020, 05, 20, 1, 2, 3), "2020-05-20");
        }

        [Test]
        public void CustomDateConversions()
        {
            // implicit conversion from date/to string
            CustomDate dt = new DateTime(2020, 05, 20, 20, 23, 00);
            string s = dt;
            Assert.AreEqual("2020-05-20", s);

            // implicit conversion from Nullable<DateTime> that has value
            dt = new DateTime?(new DateTime(2020, 05, 20, 20, 25, 00));
            s = dt;
            Assert.AreEqual("2020-05-20", s);

            // implicit conversion from Nullable<DateTime> that has no value
            dt = new DateTime?();
            s = dt;
            Assert.IsNull(s);
        }

        [Test]
        public void CustomDateTimeConversions()
        {
            // implicit conversion from date/to string
            CustomDateTime dt = new DateTime(2020, 04, 24, 1, 2, 3);
            string s = dt;
            Assert.AreEqual("2020-04-24T01:02:03Z", s);

            // implicit conversion from Nullable<DateTime> that has value
            dt = new DateTime?(new DateTime(2020, 05, 20, 20, 25, 00));
            s = dt;
            Assert.AreEqual("2020-05-20T20:25:00Z", s);

            // implicit conversion from Nullable<DateTime> that has no value
            dt = new DateTime?();
            s = dt;
            Assert.IsNull(s);
        }

        [Test]
        public void CustomDateTimeSpaceConversions()
        {
            // implicit conversion from date/to string
            CustomDateTimeSpace dt = new DateTime(2020, 05, 20, 20, 24, 00);
            string s = dt;
            Assert.AreEqual("2020-05-20 20:24:00", s);

            // implicit conversion from Nullable<DateTime> that has value
            dt = new DateTime?(new DateTime(2020, 05, 20, 20, 25, 00));
            s = dt;
            Assert.AreEqual("2020-05-20 20:25:00", s);

            // implicit conversion from Nullable<DateTime> that has no value
            dt = new DateTime?();
            s = dt;
            Assert.IsNull(s);
        }

        [Test]
        public void CustomDateTimeSerialization()
        {
            // serialization
            var thing = new CustomThing
            {
                From = new DateTime(2020, 04, 24, 1, 2, 3),
                To = null,
                Now = new DateTime?(new DateTime(2019, 12, 24, 1, 2, 3)),
                Then = new DateTime?(),
                Start = new DateTime(2020, 05, 19, 2, 48, 55),
            };

            var ss = new ServiceStackSerializer();
            var json = ss.Serialize(thing);
            Assert.NotNull(json);
            WriteLine(JsonFormatter.FormatJson(json));

            var obj = ss.Deserialize<CustomThing>(new RestResponse() { Content = json });
            Assert.NotNull(obj);
        }
    }
}
