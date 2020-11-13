using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Lookup {
    [JsonConverter(typeof(StringEnumConverter))]
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