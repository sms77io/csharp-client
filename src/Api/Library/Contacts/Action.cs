using System.Runtime.Serialization;

namespace Sms77.Api.Library.Contacts {
    public enum Action {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "write")]
        Write,
        [EnumMember(Value = "del")]
        Delete
    }
}