using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class FormatParams {
        [JsonProperty("type")]
        public const LookupType Type = LookupType.Formatting;

        [JsonProperty("number")] public string Number { get; set; }
    }
}