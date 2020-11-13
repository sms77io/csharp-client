using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Contacts {
    public class ReadParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const Action Action = Contacts.Action.Read;
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}