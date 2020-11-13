using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Pricing {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PricingFormat {
        [EnumMember(Value = "csv")]
        Csv,
        [EnumMember(Value = "json")]
        Json
    }
}