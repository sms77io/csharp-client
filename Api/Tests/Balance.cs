using System.Threading.Tasks;
using NUnit.Framework;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class Balance {
        [Test]
        public async Task TestBalance() {
            var balance = await BaseTest.Client.Balance();

            Assert.That(balance, Is.InstanceOf(typeof(double)));
        }
    }
}