using Newtonsoft.Json;

namespace Sms77.Api.Library.Voice {
    public class VoiceParams {
        [JsonProperty("text")] public string Text { get; set; }
        [JsonProperty("to")] public string To { get; set; }
        [JsonProperty("xml")] public bool Xml { get; set; }
        [JsonProperty("from")] public string From { get; set; }
    }
}