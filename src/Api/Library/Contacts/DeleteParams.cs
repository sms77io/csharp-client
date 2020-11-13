using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class DeleteParams {
        [JsonProperty("action")]
        public const Action Action = Contacts.Action.Delete;
        [JsonProperty("id")] public ulong Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}