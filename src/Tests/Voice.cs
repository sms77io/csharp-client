using System.Threading.Tasks;
using NUnit.Framework;
using Sms77.Api.Library.Voice;

namespace Sms77.Tests {
    [TestFixture]
    public class Voice {
        public static readonly VoiceParams TextParams = new VoiceParams(TestHelper.PhoneNumber, "HI2U") {
            From = TestHelper.PhoneNumber,
        };

        public static readonly VoiceParams XmlParams = new VoiceParams(TestHelper.PhoneNumber, 
            "<?xml version='1.0' encoding='UTF-8'?><Response><Say>Thanks for calling!</Say></Response>") {
            From = TestHelper.PhoneNumber,
            Xml = true
        };

        private void AssertResponseObject(Api.Library.Voice.Voice voice) {
            Assert.That(voice.Code, Is.TypeOf<ushort>());
            Assert.That(voice.Id, Is.TypeOf<uint>());
            Assert.That(voice.Cost, Is.TypeOf<double>());
        }

        [Test]
        public async Task Post() {
            AssertResponseObject(new Api.Library.Voice.Voice(await BaseTest.Client.Voice(TextParams)));
        }

        [Test]
        public async Task PostXml() {
            AssertResponseObject(new Api.Library.Voice.Voice(await BaseTest.Client.Voice(XmlParams)));
        }

        [Test]
        public async Task PostAndReturnJson() {
            AssertResponseObject(await BaseTest.Client.Voice(TextParams, true));
        }

        [Test]
        public async Task PostXmlAndReturnJson() {
            AssertResponseObject(await BaseTest.Client.Voice(XmlParams, true));
        }
    }
}