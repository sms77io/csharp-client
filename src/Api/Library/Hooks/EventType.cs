using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Hooks {
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventType {
        [EnumMember(Value = "sms_mo")]
        NewInboundSms,
        [EnumMember(Value = "dlr")]
        SmsStatusUpdate,
        [EnumMember(Value = "voice_status")]
        VoiceStatusUpdate
    }
}