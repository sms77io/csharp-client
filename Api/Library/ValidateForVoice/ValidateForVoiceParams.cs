using Newtonsoft.Json;

namespace Sms77.Api.Library.ValidateForVoice {
    public class ValidateForVoiceParams {
        [JsonProperty("callback")] public string? Callback { get; set; }
        [JsonProperty("number")] public string Number { get; set; }
    }
}