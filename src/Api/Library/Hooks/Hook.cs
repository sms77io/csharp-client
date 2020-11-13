using Newtonsoft.Json;

namespace Sms77.Api.Library.Hooks {
    public class Hook {
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("target_url")] public string TargetUrl { get; set; }
        [JsonProperty("event_type")] public EventType EventType { get; set; }
        [JsonProperty("request_method")] public RequestMethod RequestMethod { get; set; }
        [JsonProperty("created")] public string Created { get; set; }
    }
}