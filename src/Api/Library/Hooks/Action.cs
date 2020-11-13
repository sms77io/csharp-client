using System.Runtime.Serialization;

namespace Sms77.Api.Library.Hooks {
    public enum Action {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "subscribe")]
        Subscribe,
        [EnumMember(Value = "unsubscribe")]
        Unsubscribe
    }
}