using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Contacts {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Action {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "write")]
        Write,
        [EnumMember(Value = "del")]
        Delete
    }
}