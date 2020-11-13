using Newtonsoft.Json;

namespace Sms77.Api.Library.Hooks {
    public class Subscription {
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("id")] public int Id { get; set; }
    }
}