using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class HlrParams {
        [JsonProperty("type")]
        public const LookupType Type = LookupType.Hlr;

        [JsonProperty("number")] public string Number { get; set; }
    }
}