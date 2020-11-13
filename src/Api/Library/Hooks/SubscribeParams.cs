using Newtonsoft.Json;

namespace Sms77.Api.Library.Hooks {
    public class SubscribeParams {
        [JsonProperty("action")]
        public const Action Action = Hooks.Action.Subscribe;
        [JsonProperty("target_url")] public string? TargetUrl { get; set; }
        [JsonProperty("event_type")] 
        public EventType EventType { get; set; }
        [JsonProperty("request_method")] 
        public RequestMethod RequestMethod { get; set; }
    }
}