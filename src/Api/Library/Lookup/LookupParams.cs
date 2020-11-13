using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class LookupParams {
        public LookupParams(string number, LookupType type) {
            Number = number;
            Type = type;
        }
        [JsonProperty("type")] public LookupType Type { get; private set; }
        [JsonProperty("number")] public string Number { get; private set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}