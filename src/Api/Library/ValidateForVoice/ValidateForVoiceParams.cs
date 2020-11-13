using Newtonsoft.Json;

namespace Sms77.Api.Library.ValidateForVoice {
    public class ValidateForVoiceParams {
        public ValidateForVoiceParams(string number) {
            Number = number;
        }

        [JsonProperty("callback")] public string? Callback { get; set; }
        [JsonProperty("number")] public string Number { get; private set; }
    }
}