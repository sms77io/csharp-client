using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Sms77.Api.Library.ValidateForVoice;

namespace Sms77.Tests {
    [TestFixture]
    public class ValidateForVoice {
        [Test]
        public async Task Retrieve() {
            Api.Library.ValidateForVoice.ValidateForVoice validation =
                await BaseTest.Client.ValidateForVoice(new ValidateForVoiceParams {Number = TestHelper.PhoneNumber});

            Assert.That(validation.Code, TestHelper.IsDummyKey ? (IResolveConstraint) Is.Null : Is.Not.Empty);
            Assert.That(validation.Error, Is.Null);
            Assert.That(validation.Success, Is.True);
        }

        [Test]
        public async Task RetrieveInvalidNumber() {
            const string number = "ThisAintGonnaWork!";

            var v =
                await BaseTest.Client.ValidateForVoice(
                    new ValidateForVoiceParams {Callback = null, Number = number});

            Assert.That(v.Success, TestHelper.IsDummyKey ? (IResolveConstraint) Is.True : Is.False);
            Assert.That(v.Id, Is.Null);
            Assert.That(v.FormattedOutput, Is.Null);
            Assert.That(v.Error, TestHelper.IsDummyKey ? (IResolveConstraint) Is.Null : Is.Not.Null);
            Assert.That(v.Voice, TestHelper.IsDummyKey ? (IResolveConstraint) Is.Null : Is.False);
            Assert.AreEqual(v.Sender, TestHelper.IsDummyKey ? null : number);
        }
    }
}