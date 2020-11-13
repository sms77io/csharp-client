using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    public class ReadParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const Action Action = Hooks.Action.Read;
    }
}