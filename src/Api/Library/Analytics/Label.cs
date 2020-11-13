using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Analytics {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Label {
        [EnumMember(Value = "all")]
        All
    }
}