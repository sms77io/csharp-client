using System;

namespace Sms77.Api.Tests {
    internal static class TestHelper {
        internal static readonly string ApiDummyKeyEnvProperty = "SMS77_DUMMY_API_KEY";
        internal static readonly string ApiKeyEnvProperty = "SMS77_API_KEY";
        internal static readonly string ApiKey;
        internal static readonly string PhoneNumber = "+491771783130";
        internal static readonly string MyPhoneNumber = Environment.GetEnvironmentVariable("SMS77_TO") ?? PhoneNumber;
        internal static readonly bool IsDummyKey;

        static TestHelper() {
            var (apiKey, isDummy) = GetEnvCredentials();

            ApiKey = apiKey;
            IsDummyKey = isDummy;
        }

        internal static Tuple<string?, bool> GetEnvCredentials() {
            var apiKey = Environment.GetEnvironmentVariable(ApiDummyKeyEnvProperty);
            var isDummy = true;

            if (null == apiKey) {
                isDummy = false;

                apiKey = Environment.GetEnvironmentVariable(ApiKeyEnvProperty);
            }

            return new Tuple<string?, bool>(apiKey, isDummy);
        }
    }
}