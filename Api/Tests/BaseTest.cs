using NUnit.Framework;

namespace Sms77.Api.Tests {
    [SetUpFixture]
    public class BaseTest {
        internal static Client Client;

        [OneTimeSetUp]
        public void Setup() {
            if (string.IsNullOrWhiteSpace(TestHelper.ApiKey)) {
                throw new MissingEnvironmentVariableException(
                    $@"Please set environment variable 
                            {TestHelper.ApiDummyKeyEnvProperty} or {TestHelper.ApiKeyEnvProperty}");
            }

            Client = new Client(TestHelper.ApiKey, "CSharp-Test", false);
        }
    }
}