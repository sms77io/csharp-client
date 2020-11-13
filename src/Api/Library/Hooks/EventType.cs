using System.Runtime.Serialization;

namespace Sms77.Api.Library.Hooks {
    public enum EventType {
        [EnumMember(Value = "sms_mo")]
        NewInboundSms,
        [EnumMember(Value = "dlr")]
        SmsStatusUpdate,
        [EnumMember(Value = "voice_status")]
        VoiceStatusUpdate
    }
}