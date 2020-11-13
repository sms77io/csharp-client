using System.Runtime.Serialization;

namespace Sms77.Api.Library.Analytics {
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