using System.Runtime.Serialization;

namespace Sms77.Api.Library.Lookup {
    public enum LookupType {
        [EnumMember(Value = "format")]
        Formatting,
        [EnumMember(Value = "cnam")]
        Cnam,
        [EnumMember(Value = "hlr")]
        Hlr,
        [EnumMember(Value = "mnp")]
        Mnp
    }
}