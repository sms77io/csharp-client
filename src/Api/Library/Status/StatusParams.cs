using Newtonsoft.Json;

namespace Sms77.Api.Library.Status {
    public class StatusParams {
        public StatusParams(ulong msgId) {
            MsgId = msgId;
        }

        [JsonProperty("msg_id")] public ulong MsgId { get; private set; }
    }
}