using Newtonsoft.Json;

namespace Sms77.Api.Library.Lookup {
    public class MnpLookup {
        [JsonProperty("price")] public double Price { get; set; }
        [JsonProperty("success")] public bool Success { get; set; }
        [JsonProperty("code")] public uint Code { get; set; }
        [JsonProperty("mnp")] public Mnp Mnp { get; set; }
    }
}