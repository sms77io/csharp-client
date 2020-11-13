using System.Runtime.Serialization;

namespace Sms77.Api.Library.Analytics {
    public enum Subaccount {
        [EnumMember(Value = "only_main")]
        OnlyMain,
        [EnumMember(Value = "all")]
        All
    }
}