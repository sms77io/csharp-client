using Newtonsoft.Json;

namespace Sms77.Api.Library.Hooks {
    public class Read {
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("hooks")] public Entry[] Entries { get; set; }
    }
}