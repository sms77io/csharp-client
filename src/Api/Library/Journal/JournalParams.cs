using Newtonsoft.Json;

namespace Sms77.Api.Library.Journal {
    public class JournalParams {
        public JournalParams(Type type) {
            Type = type;
        }

        private string? _dateTo;
        private string? _dateFrom;

        [JsonProperty("date_from")]
        public string? DateFrom {
            get => _dateFrom;
            set {
                ValidateDate(value, "DateFrom");

                _dateFrom = value;
            }
        }

        [JsonProperty("date_to")]
        public string? DateTo {
            get => _dateTo;
            set {
                ValidateDate(value, "DateTo");

                _dateTo = value;
            }
        }

        [JsonProperty("id")] public int? Id { get; set; }

        private void ValidateDate(string? date, string paramName) {
            if (null != date && !Tools.IsValidDate(date)) {
                throw new ApiException($"Invalid date value {date} for param {paramName}");
            }
        }

        [JsonProperty("state")] public string? State { get; set; }
        [JsonProperty("to")] public string? To { get; set; }
        [JsonProperty("type")] public Type Type { get; private set; }
    }
}