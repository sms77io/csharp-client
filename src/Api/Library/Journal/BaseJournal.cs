using Newtonsoft.Json;

namespace Sms77.Api.Library.Journal {
    public abstract class BaseJournal {
        protected BaseJournal(
            string from,
            string id,
            string price,
            string text,
            string timestamp,
            string to
        ) {
            From = from;
            Id = id;
            Price = price;
            Text = text;
            Timestamp = timestamp;
            To = to;
        }

        [JsonProperty("from")] public string From { get; private set; }
        [JsonProperty("id")] public string Id { get; private set; }
        [JsonProperty("price")] public string Price { get; private set; }
        [JsonProperty("text")] public string Text { get; private set; }
        [JsonProperty("timestamp")] public string Timestamp { get; private set; }
        [JsonProperty("to")] public string To { get; private set; }
    }
}