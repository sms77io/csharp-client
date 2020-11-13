using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class DeleteParams {
        public DeleteParams() {
            var c = new BaseClient("");
            //c.ApiKey = "";
            var k = c.ApiKey;
        }
        
        [JsonProperty("action")]
        public const Action Action = Contacts.Action.Delete;
        [JsonProperty("id")] public ulong Id { get; set; }
        [JsonProperty("json")] public bool? Json { get; set; }
    }
}