using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestMethod {
        [EnumMember(Value = "GET")]
        Get,
        [EnumMember(Value = "POST")]
        Post
    }
}