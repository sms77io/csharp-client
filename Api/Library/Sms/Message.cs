using Newtonsoft.Json;

namespace Sms77.Api.Library.Sms {
    public class Message {
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("sender")] public string Sender { get; set; }
        [JsonProperty("recipient")] public string Recipient { get; set; }
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("encoding")] public string Encoding { get; set; }
        [JsonProperty("parts")] public ushort Parts { get; set; }
        [JsonProperty("price")] public double Price { get; set; }
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("error")] public string Error { get; set; }
        [JsonProperty("error_text")] public string ErrorText { get; set; }
    }
}