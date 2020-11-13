using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    public class UnsubscribeParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const Action Action = Hooks.Action.unsubscribe;
        [JsonProperty("id")] public int Id { get; set; }
    }
}