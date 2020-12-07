using Newtonsoft.Json;

namespace Sms77.Api.Library.Journal {
    public class JournalVoice : BaseJournal {
        public JournalVoice(
            string from,
            string id,
            string price,
            string text,
            string timestamp,
            string to,
            string duration,
            string error,
            string status,
            bool xml
        ) : base(from, id, price, text, timestamp, to) {
            Duration = duration;
            Error = error;
            Status = status;
            Xml = xml;
        }

        [JsonProperty("duration")] public string Duration { get; private set; }
        [JsonProperty("error")] public string Error { get; private set; }
        [JsonProperty("status")] public string Status { get; private set; }
        [JsonProperty("xml")] public bool Xml { get; private set; }
    }
}