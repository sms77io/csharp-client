using Sms77.Api;
using Sms77.Tests;

namespace Sms77.Examples {
    class BaseExample {
        protected static readonly Client Client = new Client(TestHelper.ApiKey);
    }
}