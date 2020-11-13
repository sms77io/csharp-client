using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Pricing {
    public class Country {
        [JsonProperty("countryCode")] public string CountryCode { get; set; }
        [JsonProperty("countryName")] public string CountryName { get; set; }
        [JsonProperty("countryPrefix")] public string CountryPrefix { get; set; }
        [JsonProperty("networks")] public List<Network> Networks { get; set; }
    }
}