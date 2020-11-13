using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Lookup {
    public class HlrParams {
        [JsonProperty("type"), JsonConverter(typeof(StringEnumConverter))]
        public const LookupType Type = LookupType.Hlr;

        [JsonProperty("number")] public string Number { get; set; }
    }
}