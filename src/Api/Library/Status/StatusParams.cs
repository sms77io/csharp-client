using Newtonsoft.Json;

namespace Sms77.Api.Library.Status {
    public class StatusParams {
        [JsonProperty("msg_id")] public ulong MsgId { get; set; }
    }
}