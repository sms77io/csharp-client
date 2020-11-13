using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class ContactsParams {
        [JsonProperty("action")]
        public Action Action { get; set; }

        [JsonProperty("email")] public string? Email { get; set; }
        [JsonProperty("empfaenger")] public string? Empfaenger { get; set; }
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
        [JsonProperty("nick")] public string? Nick { get; set; }
    }
}