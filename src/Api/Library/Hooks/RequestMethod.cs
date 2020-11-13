using System.Runtime.Serialization;

namespace Sms77.Api.Library.Hooks {
    public enum RequestMethod {
        [EnumMember(Value = "GET")]
        Get,
        [EnumMember(Value = "POST")]
        Post
    }
}