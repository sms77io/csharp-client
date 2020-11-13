using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    public class SubscribeParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const Action Action = Hooks.Action.Subscribe;
        [JsonProperty("target_url")] public string? TargetUrl { get; set; }
        [JsonProperty("event_type"), JsonConverter(typeof(StringEnumConverter))] 
        public EventType EventType { get; set; }
        [JsonProperty("request_method"), JsonConverter(typeof(StringEnumConverter))] 
        public RequestMethod RequestMethod { get; set; }
    }
}