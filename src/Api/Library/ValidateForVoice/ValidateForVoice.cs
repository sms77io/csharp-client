using Newtonsoft.Json;

namespace Sms77.Api.Library.ValidateForVoice {
    public class ValidateForVoice {
        [JsonProperty("code")] public string? Code { get; set; }
        [JsonProperty("error")] public string? Error { get; set; }
        [JsonProperty("formatted_output")] public string? FormattedOutput { get; set; }
        [JsonProperty("id")] public long? Id { get; set; }
        [JsonProperty("sender")] public string? Sender { get; set; }
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("voice")] public bool? Voice { get; set; }

        public override string ToString() {
            return $@"
            Success: {Success}
            Id: {Id}
            FormattedOutput: {FormattedOutput}
            Error: {Error}
            Voice: {Voice}
            Sender: {Sender}
            ";
        }
    }
}