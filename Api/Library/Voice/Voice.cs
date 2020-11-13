using System;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Voice {
    public class Voice {
        public Voice(string response = null) {
            if (null != response) {
                var lines = Util.SplitByLine(response);

                Code = Convert.ToUInt16(lines[0]);
                Id = Convert.ToUInt32(lines[1]);
                Cost = Convert.ToDouble(lines[2]);
            }
        }

        [JsonProperty("code")] public ushort Code { get; set; }
        [JsonProperty("id")] public uint Id { get; set; }
        [JsonProperty("cost")] public double Cost { get; set; }
    }
}