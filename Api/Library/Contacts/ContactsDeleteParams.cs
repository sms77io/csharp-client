using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Contacts {
    public class ContactsDeleteParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const ContactsAction Action = ContactsAction.del;
        [JsonProperty("id")] public ulong Id { get; set; }
        [JsonProperty("json")] public bool Json { get; set; }
    }
}