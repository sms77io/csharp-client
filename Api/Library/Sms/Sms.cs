using Newtonsoft.Json;

namespace Sms77.Api.Library.Sms {
    public class Sms {
        [JsonProperty("success")] public string Success { get; set; }
        [JsonProperty("total_price")] public double TotalPrice { get; set; }
        [JsonProperty("balance")] public double Balance { get; set; }
        [JsonProperty("debug")] public string Debug { get; set; }
        [JsonProperty("sms_type")] public string SmsType { get; set; }
        [JsonProperty("messages")] public Message[] Messages { get; set; }
    }
}