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
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventType {
        [EnumMember(Value = "sms_mo")]
        NewInboundSms,
        [EnumMember(Value = "dlr")]
        SmsStatusUpdate,
        [EnumMember(Value = "voice_status")]
        VoiceStatusUpdate
    }
    
    [JsonConverter(typeof(StringEnumConverter))]
    public enum RequestMethod {
        [EnumMember(Value = "GET")]
        Get,
        [EnumMember(Value = "POST")]
        Post
    }
}