using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class Mnp {
        [JsonProperty("country")] public string Country { get; set; }
        [JsonProperty("number")] public string Number { get; set; }

        [JsonProperty("international_formatted")]
        public string InternationalFormatted { get; set; }

        [JsonProperty("national_format")] public string NationalFormat { get; set; }
        [JsonProperty("network")] public string Network { get; set; }
        [JsonProperty("mccmnc")] public string MccMnc { get; set; }
        [JsonProperty("isPorted")] public bool IsPorted { get; set; }
    }
}