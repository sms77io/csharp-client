using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Sms77.Api.Library;
using Sms77.Api.Library.Status;

namespace Sms77.Tests {
    [TestFixture]
    public class Status {
        private readonly StatusParams _statusParams = new StatusParams {MsgId = 77131047375};

        private void AssertStatus(Api.Library.Status.Status status) {
            var codes = Enum.GetNames(typeof(StatusCode));
            var pattern = string.Join("|", codes);
            var isValidDate = Util.IsValidDate(status.Timestamp, "yyyy-MM-dd HH:mm:ss.fff");

            StringAssert.IsMatch(pattern, status.Code);
            Assert.That(isValidDate, Is.True);
        }

        [Test]
        public async Task Retrieve() {
            string response = await BaseTest.Client.Status(_statusParams);
            Api.Library.Status.Status status = Api.Library.Status.Status.FromString(response);

            AssertStatus(status);
        }

        [Test]
        public async Task RetrieveJson() {
            Api.Library.Status.Status status = await BaseTest.Client.Status(_statusParams, true);

            AssertStatus(status);
        }
    }
}