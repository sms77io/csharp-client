using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class ReadParams {
        [JsonProperty("action")]
        public const Action Action = Contacts.Action.Read;
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}