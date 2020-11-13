namespace Sms77.Api.Library.Sms {
    public static class Tools {
        public static SmsParams DefaultParams = new SmsParams {
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