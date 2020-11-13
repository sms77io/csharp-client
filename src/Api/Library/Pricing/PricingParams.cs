using Newtonsoft.Json;

namespace Sms77.Api.Library.Pricing {
    public class PricingParams {
        [JsonProperty("format")]
        public PricingFormat? Format { get; set; } = PricingFormat.Json;

        [JsonProperty("country")] public string? Country { get; set; }
    }
}