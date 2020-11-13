using Newtonsoft.Json;

namespace Sms77.Api.Library.Analytics {
    public class Analytics {
        [JsonProperty("account")] public string? Account { get; private set; }
        [JsonProperty("country")] public string? Country { get; private set; }
        [JsonProperty("date")] public string? Date { get; private set; }
        [JsonProperty("direct")] public int Direct { get; private set; }
        [JsonProperty("economy")] public int Economy { get; private set; }
        [JsonProperty("hlr")] public int Hlr { get; private set; }
        [JsonProperty("inbound")] public int Inbound { get; private set; }
        [JsonProperty("label")] public string? Label { get; private set; }
        [JsonProperty("mnp")] public int Mnp { get; private set; }
        [JsonProperty("voice")] public int Voice { get; private set; }
        [JsonProperty("usage_eur")] public double UsageEur { get; set; }
    }
}