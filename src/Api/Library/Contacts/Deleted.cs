using System;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class Deleted {
        public static Deleted FromCsv(string csv) {
            return new Deleted {Return = Convert.ToUInt16(csv.Trim())};
        }

        [JsonProperty("return")] public uint Return { get; set; }
    }
}