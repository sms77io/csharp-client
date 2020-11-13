using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Contacts {
    public class ContactsReadParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const ContactsAction Action = ContactsAction.read;
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("json")] public bool Json { get; set; }
    }
}