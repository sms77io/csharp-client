using System;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class Written {
        public static Written FromCsv(string csv) {
            var lines = Util.SplitByLine(csv);

            return new Written {Id = Convert.ToUInt64(lines[1]), Return = Convert.ToUInt16(lines[0])};
        }

        [JsonProperty("id")] public ulong Id { get; set; }
        [JsonProperty("return")] public uint Return { get; set; }
    }
}