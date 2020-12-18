using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Sms77.Api.Library;
using Sms77.Api.Library.Sms;

namespace Sms77.Tests {
    [TestFixture]
    public class Sms {
        private readonly string _successCode = "100";

        [Test]
        public void Validator() {
            Assert.True(new Validator(new SmsParams("x", "y") {
                Debug = false,
                Delay = "1608307189506",
                Details = true,
                Flash = true,
                ForeignId = new string('0', ForeignId.MaxLength),
                From = "a",
                Json = false,
                Label = new string('0', Label.MaxLength),
                NoReload = true,
                PerformanceTracking = false,
                ReturnMsgId = true,
                Ttl = Ttl.Min - 0,
                Udh = "",
                Unicode = false,
                Utf8 = true,
            }).Valid);

            Assert.True(new Validator(new SmsParams("x", "y") {
                ForeignId = new string('0', ForeignId.MaxLength + 1),
            }).ForeignId.Invalid);
            
            Assert.True(new Validator(new SmsParams("", "y")).To.Invalid);
        }

        [Test]
        public async Task Single() {
            Assert.That(await BaseTest.Client.Sms(new SmsParams(TestHelper.MyPhoneNumber, "HI2U!") {
                    Flash = true,
                    From = TestHelper.PhoneNumber,
                    Delay = $"{DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 60}",
                    Label = "TestLabel",
                    Ttl = 300000,
                    NoReload = true,
                    PerformanceTracking = true,
                    ForeignId = "MyTestForeignId",
                }),
                Is.EqualTo(_successCode));
        }

        [Test]
        public async Task SingleDetailed() {
            SmsParams paras = new SmsParams(TestHelper.MyPhoneNumber, "HI2U!")
                {From = TestHelper.PhoneNumber, Details = true};

            AssertDetailed(Util.SplitByLine(await BaseTest.Client.Sms(paras)), paras.Text);
        }

        [Test]
        public async Task SingleReturnMsgId() {
            string[] lines = Util.SplitByLine(
                await BaseTest.Client.Sms(new SmsParams(TestHelper.MyPhoneNumber, "HI2U!")
                    {From = TestHelper.PhoneNumber, ReturnMsgId = true}));

            Assert.That(lines[0], Is.EqualTo(_successCode));
            Assert.That(lines[1], Is.EqualTo("1234567890"));
        }

        [Test]
        public async Task SingleDetailedWithMsgId() {
            SmsParams paras = new SmsParams(TestHelper.MyPhoneNumber, "HI2U!")
                {From = TestHelper.PhoneNumber, ReturnMsgId = true, Details = true};

            string[] lines = Util.SplitByLine(await BaseTest.Client.Sms(paras));

            AssertDetailed(lines.Where((source, index) => index != 1).ToArray(), paras.Text);
        }

        [Test]
        public async Task SingleJson() {
            SmsParams paras = new SmsParams(TestHelper.MyPhoneNumber, "HI2U!")
                {From = TestHelper.PhoneNumber, Json = true};

            AssertJson(await BaseTest.Client.Sms(paras));
        }

        private void AssertJson(Api.Library.Sms.Sms sms) {
            var debug = "true" == sms.Debug;
            double totalPrice = 0;

            foreach (var message in sms.Messages) {
                totalPrice += message.Price;

                AssertMessage(message, debug);
            }

            Assert.That(sms.Balance, Is.Positive);
            Assert.That(sms.Debug, Is.EqualTo(debug ? "true" : "false"));
            Assert.That(sms.Messages, Is.Not.Empty);
            Assert.That(sms.Success, Is.EqualTo(_successCode));
            StringAssert.IsMatch("direct|economy", sms.SmsType);
            Assert.That(sms.TotalPrice, Is.EqualTo(totalPrice));
        }

        private void AssertMessage(Message msg, bool debug) {
            Assert.That(msg.Encoding, Is.Not.Empty);
            Assert.That(msg.Error, Is.Null);
            Assert.That(msg.ErrorText, Is.Null);
            Assert.That(msg.Parts, Is.Positive);
            Assert.That(msg.Recipient, Is.Not.Empty);
            Assert.That(msg.Sender, Is.Not.Empty);
            Assert.That(msg.Success, Is.True);
            Assert.That(msg.Text, Is.Not.Empty);

            if (debug) {
                Assert.That(msg.Id, Is.Null);
                Assert.That(msg.Price, Is.Zero);
            }
            else {
                Assert.That(msg.Id, Is.Positive);
                Assert.That(msg.Price, Is.Positive);
            }
        }

        private void AssertDetailed(string[] lines, string text) {
            Assert.That(lines[0], Is.EqualTo(_successCode));
            StringAssert.StartsWith("Verbucht: ", lines[1]);
            StringAssert.StartsWith("Preis: ", lines[2]);
            StringAssert.StartsWith("Guthaben: ", lines[3]);
            Assert.That(lines[4], Is.EqualTo($"Text: {text}"));
            Assert.That(lines[5], Is.EqualTo("SMS-Typ: direct"));
            Assert.That(lines[6], Is.EqualTo("Flash SMS: false"));
            Assert.That(lines[7], Is.EqualTo("Encoding: gsm"));
            Assert.That(lines[8], Is.EqualTo("GSM0338: true"));
            Assert.That(lines[9], Is.EqualTo("Debug: true"));
        }
    }
}