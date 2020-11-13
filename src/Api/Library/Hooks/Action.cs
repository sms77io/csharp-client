using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Action {
        [EnumMember(Value = "read")]
        Read,
        [EnumMember(Value = "subscribe")]
        Subscribe,
        [EnumMember(Value = "unsubscribe")]
        Unsubscribe
    }
}