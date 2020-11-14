using NUnit.Framework;
using Sms77.Api;
using Sms77.Api.Library;

namespace Sms77.Tests {
    [TestFixture]
    public class Instance {
        [Test]
        public void TestBalanceFails() {
            Assert.Throws<AuthException>(() => new Client(""));
        }
        
        [Test]
        public void TestApiKey() {
            Assert.AreEqual(BaseTest.Client.ApiKey, TestHelper.ApiKey);
        }
        
        [Test]
        public void TestDebug() {
            Assert.AreEqual(BaseTest.Client.SentWith, BaseTest.SentWith);
        }
        
        [Test]
        public void TestSentWith() {
            Assert.AreEqual(BaseTest.Client.Debug, BaseTest.Debug);
        }
    }
}