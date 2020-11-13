using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Lookup {
    public class LookupHlrParams {
        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public const LookupType Type = LookupType.hlr;

        [JsonProperty("number")] public string Number { get; set; }
    }
}