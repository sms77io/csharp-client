using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Pricing {
    public class PricingParams {
        [JsonProperty("format"), JsonConverter(typeof(StringEnumConverter))]
        public PricingFormat? Format { get; set; } = PricingFormat.json;

        [JsonProperty("country")] public string? Country { get; set; }
    }
}