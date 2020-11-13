using System;
using System.Linq;
using Newtonsoft.Json;

namespace Sms77.Api.Library.Contacts {
    public class Contact {
        public static Contact FromCsv(string csv) {
            var values = csv.Split(";", StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < values.Length; i++) {
                values[i] = values[i].Trim();

                string first = values[i].First().ToString();
                string last = values[i].Last().ToString();

                if ("\"" == first && "\"" == last) {
                    values[i] = values[i].Substring(1, values[i].Length - 2);
                }
            }

            return new Contact {Id = Convert.ToUInt64(values[0]), Name = values[1], Number = values[2]};
        }

        [JsonProperty("ID")] public ulong Id { get; set; }
        [JsonProperty("Name")] public string Name { get; set; }
        [JsonProperty("Number")] public string Number { get; set; }
    }
}