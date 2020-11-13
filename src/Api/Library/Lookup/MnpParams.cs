using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class MnpParams {
        [JsonProperty("type")]
        public const LookupType Type = LookupType.Mnp;

        [JsonProperty("number")] public string Number { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}