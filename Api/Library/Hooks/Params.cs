using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    public class Params {
        [JsonProperty("id")] public int? Id { get; set; }
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))] public Action Action { get; set; }
        [JsonProperty("target_url")] public string? TargetUrl { get; set; }
        [JsonProperty("event_type"), JsonConverter(typeof(StringEnumConverter))] 
        public EventType? EventType { get; set; }
        [JsonProperty("request_method"), JsonConverter(typeof(StringEnumConverter))] 
        public RequestMethod? RequestMethod { get; set; }
    }
}