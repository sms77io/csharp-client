using Newtonsoft.Json;

namespace Sms77.Api.Library.Status {
    public class Status {
        public static Status FromString(string response) {
            string[] lines = Util.SplitByLine(response);

            return new Status {
                Code = lines[0],
                Timestamp = lines[1],
            };
        }
        
        [JsonProperty("code")] public string Code { get; set; }
        [JsonProperty("timestamp")] public string Timestamp { get; set; }
    }
}