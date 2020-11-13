using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Lookup {
    public class MnpParams {
        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public const LookupType Type = LookupType.mnp;

        [JsonProperty("number")] public string Number { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}