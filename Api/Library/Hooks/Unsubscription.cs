using Newtonsoft.Json;

namespace Sms77.Api.Library.Hooks {
    public class Unsubscription {
        [JsonProperty("success")] public bool Success { get; set; }
    }
}