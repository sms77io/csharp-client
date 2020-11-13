using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class CnamLookup {
        [JsonProperty("success")] public string Success { get; set; }
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("number")] public string Number { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
    }
}