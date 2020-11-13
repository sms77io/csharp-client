using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Contacts {
    public class DeleteParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const Action Action = Contacts.Action.Delete;
        [JsonProperty("id")] public ulong Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}