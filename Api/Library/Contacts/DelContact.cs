using System;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class DelContact {
        public static DelContact FromCsv(string csv) {
            return new DelContact {Return = Convert.ToUInt16(csv.Trim())};
        }

        [JsonProperty("return")] public uint Return { get; set; }
    }
}