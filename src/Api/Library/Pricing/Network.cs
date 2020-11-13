using System.Collections.Generic;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Pricing {
    public class Network {
        [JsonProperty("mcc")] public string Mcc { get; set; }
        [JsonProperty("mncs")] public List<string> Mncs { get; set; }
        [JsonProperty("networkName")] public string NetworkName { get; set; }
        [JsonProperty("price")] public double Price { get; set; }
        [JsonProperty("features")] public List<string> Features { get; set; }
        [JsonProperty("comment")] public string Comment { get; set; }
    }
}