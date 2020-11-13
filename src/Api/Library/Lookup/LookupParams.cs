using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class LookupParams {
        [JsonProperty("type")] public LookupType Type { get; set; }
        [JsonProperty("number")] public string Number { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}