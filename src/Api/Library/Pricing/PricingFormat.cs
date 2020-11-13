using System.Runtime.Serialization;

namespace Sms77.Api.Library.Pricing {
    public enum PricingFormat {
        [EnumMember(Value = "csv")]
        Csv,
        [EnumMember(Value = "json")]
        Json
    }
}