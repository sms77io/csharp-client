using Newtonsoft.Json;

namespace Sms77.Api.Library.Journal {
    public class JournalOutbound : BaseJournal {
        public JournalOutbound(
            string from,
            string id,
            string price,
            string text,
            string timestamp,
            string to,
            string connection,
            string type
        ) : base(from, id, price, text, timestamp, to) {
            Connection = connection;
            Type = type;
        }

        [JsonProperty("connection")] public string Connection { get; private set; }
        [JsonProperty("dlr")] public string? Dlr { get; private set; }
        [JsonProperty("dlr_timestamp")] public string? DlrTimestamp { get; private set; }
        [JsonProperty("foreign_id")] public string? ForeignId { get; private set; }
        [JsonProperty("label")] public string? Label { get; private set; }
        [JsonProperty("latency")] public string? Latency { get; private set; }
        [JsonProperty("mccmnc")] public string? MccMnc { get; private set; }
        [JsonProperty("type")] public string Type { get; private set; }
    }
}