using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library {
    public enum PricingFormat {
        csv,
        json
    }

    public class Country {
        [JsonProperty("countryCode")] public string CountryCode { get; set; }
        [JsonProperty("countryName")] public string CountryName { get; set; }
        [JsonProperty("countryPrefix")] public string CountryPrefix { get; set; }
        [JsonProperty("networks")] public List<Network> Networks { get; set; }
    }

    public class Pricing {
        [JsonProperty("countCountries")] public int CountCountries { get; set; }
        [JsonProperty("countNetworks")] public int CountNetworks { get; set; }
        [JsonProperty("countries")] public List<Country> Countries { get; set; }
    }

    public class Network {
        [JsonProperty("mcc")] public string Mcc { get; set; }
        [JsonProperty("mncs")] public List<string> Mncs { get; set; }
        [JsonProperty("networkName")] public string NetworkName { get; set; }
        [JsonProperty("price")] public double Price { get; set; }
        [JsonProperty("features")] public List<string> Features { get; set; }
        [JsonProperty("comment")] public string Comment { get; set; }
    }

    public class PricingParams {
        [JsonProperty("format"), JsonConverter(typeof(StringEnumConverter))]
        public PricingFormat? Format { get; set; } = PricingFormat.json;

        [JsonProperty("country")] public string? Country { get; set; }
    }
}