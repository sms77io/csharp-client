using Newtonsoft.Json;

namespace Sms77.Api.Library.Hooks {
    public class UnsubscribeParams {
        [JsonProperty("action")]
        public const Action Action = Hooks.Action.Unsubscribe;
        [JsonProperty("id")] public int Id { get; set; }
    }
}