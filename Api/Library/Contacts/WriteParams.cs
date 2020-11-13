using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Contacts {
    public class WriteParams {
        [JsonProperty("action"), JsonConverter(typeof(StringEnumConverter))]
        public const Action Action = Contacts.Action.write;

        [JsonProperty("email")] public string? Email { get; set; }
        [JsonProperty("empfaenger")] public string? Empfaenger { get; set; }
        [JsonProperty("id")] public ulong? Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
        [JsonProperty("nick")] public string? Nick { get; set; }
    }
}