namespace Sms77.Api.Library.Sms {
    public static class Tools {
        public static SmsParams DefaultParams(string to, string text) {
            return new SmsParams(to, text) {
                Debug = false,
                Delay = null,
                Details = false,
                Flash = false,
                ForeignId = null,
                From = null,
                Json = false,
                Label = null,
                NoReload = false,
                Ttl = 86400000,
                Udh = null,
                Unicode = false,
                Utf8 = false,
                PerformanceTracking = false,
                ReturnMsgId = false
            };
        }
    }
}