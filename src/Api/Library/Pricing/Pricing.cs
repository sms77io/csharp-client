using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Pricing {
    public class Pricing {
        [JsonProperty("countCountries")] public int CountCountries { get; set; }
        [JsonProperty("countNetworks")] public int CountNetworks { get; set; }
        [JsonProperty("countries")] public List<Country> Countries { get; set; }
    }
}