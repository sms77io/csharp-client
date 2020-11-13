using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class FormatLookup {
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("international")] public string International { get; set; }

        [JsonProperty("international_formatted")]
        public string InternationalFormatted { get; set; }

        [JsonProperty("national")] public string National { get; set; }
        [JsonProperty("country_iso")] public string CountryIso { get; set; }
        [JsonProperty("country_name")] public string CountryName { get; set; }
        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("carrier")] public string Carrier { get; set; }
        [JsonProperty("network_type")] public string NetworkType { get; set; }
    }
}