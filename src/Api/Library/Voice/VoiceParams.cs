using Newtonsoft.Json;

namespace Sms77.Api.Library.Voice {
    public class VoiceParams {
        public VoiceParams(string to, string text) {
            To = to;
            Text = text;
        }

        [JsonProperty("text")] public string Text { get; private set; }
        [JsonProperty("to")] public string To { get; private set; }
        [JsonProperty("xml")] public bool? Xml { get; set; }
        [JsonProperty("from")] public string? From { get; set; }
    }
}