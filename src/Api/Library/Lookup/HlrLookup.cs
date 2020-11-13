using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class HlrLookup {
        [JsonProperty("status")] public bool Status { get; set; }
        [JsonProperty("status_message")] public string StatusMessage { get; set; }
        [JsonProperty("lookup_outcome")] public bool LookupOutcome { get; set; }

        [JsonProperty("lookup_outcome_message")]
        public string LookupOutcomeMessage { get; set; }

        [JsonProperty("international_format_number")]
        public string InternationalFormatNumber { get; set; }

        [JsonProperty("international_formatted")]
        public string InternationalFormatted { get; set; }

        [JsonProperty("national_format_number")]
        public string NationalFormatNumber { get; set; }

        [JsonProperty("country_code")] public string CountryCode { get; set; }
        [JsonProperty("country_name")] public string CountryName { get; set; }
        [JsonProperty("country_prefix")] public string CountryPrefix { get; set; }
        [JsonProperty("current_carrier")] public Carrier CurrentCarrier { get; set; }
        [JsonProperty("original_carrier")] public Carrier OriginalCarrier { get; set; }
        [JsonProperty("valid_number")] public string ValidNumber { get; set; }
        [JsonProperty("reachable")] public string Reachable { get; set; }
        [JsonProperty("ported")] public string Ported { get; set; }
        [JsonProperty("roaming")] public string Roaming { get; set; }
        [JsonProperty("gsm_code")] public string GsmCode { get; set; }
        [JsonProperty("gsm_message")] public string GsmMessage { get; set; }
    }
}