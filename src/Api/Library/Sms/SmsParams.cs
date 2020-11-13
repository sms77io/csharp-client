using Newtonsoft.Json;

namespace Sms77.Api.Library.Sms {
    public class SmsParams {
        public SmsParams(string to, string text) {
            To = to;
            Text = text;
        }

        [JsonProperty("to")] public string To { get; private set; }
        [JsonProperty("text")] public string Text { get; private set; }
        [JsonProperty("from")] public string? From { get; set; }
        [JsonProperty("debug")] public bool? Debug { get; set; }
        [JsonProperty("delay")] public string? Delay { get; set; }
        [JsonProperty("no_reload")] public bool? NoReload { get; set; }
        [JsonProperty("unicode")] public bool? Unicode { get; set; }
        [JsonProperty("flash")] public bool? Flash { get; set; }
        [JsonProperty("udh")] public string? Udh { get; set; }
        [JsonProperty("utf8")] public bool? Utf8 { get; set; }
        [JsonProperty("ttl")] public int? Ttl { get; set; }
        [JsonProperty("details")] public bool? Details { get; set; }
        [JsonProperty("return_msg_id")] public bool? ReturnMsgId { get; set; }
        [JsonProperty("label")] public string? Label { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
        [JsonProperty("performance_tracking")] public bool? PerformanceTracking { get; set; }
        [JsonProperty("foreign_id")] public string? ForeignId { get; set; }
    }
}