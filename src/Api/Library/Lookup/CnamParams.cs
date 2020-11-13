using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class CnamParams {
        [JsonProperty("type")]
        public const LookupType Type = LookupType.Cnam;

        [JsonProperty("number")] public string Number { get; set; }
    }
}