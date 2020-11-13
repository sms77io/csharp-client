using Newtonsoft.Json;

namespace Sms77.Api.Library.Hooks {
    public class ReadParams {
        [JsonProperty("action")]
        public const Action Action = Hooks.Action.Read;
    }
}