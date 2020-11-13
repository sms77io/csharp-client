using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class ContactsParams {
        public ContactsParams(Action action) {
            Action = action;
        }
        
        [JsonProperty("action")] public Action Action { get; private set; }
        [JsonProperty("email")] public string? Email { get; set; }
        [JsonProperty("empfaenger")] public string? Recipient { get; set; }
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
        [JsonProperty("nick")] public string? Nick { get; set; }
    }
}