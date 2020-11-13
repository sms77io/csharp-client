using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Analytics {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupBy {
        [EnumMember(Value = "date")]
        Date,
        [EnumMember(Value = "label")]
        Label,
        [EnumMember(Value = "subaccount")]
        Subaccount,
        [EnumMember(Value = "country")]
        Country
    }
}