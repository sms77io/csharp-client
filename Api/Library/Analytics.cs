using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library {
    public static class Tools {
        public static AnalyticsParams DefaultParams = new AnalyticsParams {
            End = DateTime.Today.ToString(DateFormat),
            GroupBy = GroupBy.date,
            Label = Enum.GetName(typeof(Label), Label.all),
            Start = DateTime.Today.AddDays(-30).ToString(DateFormat),
            Subaccounts = Enum.GetName(typeof(Subaccount), Subaccount.only_main)
        };

        private const string DateFormat = "yyyy-M-d";

        public static bool IsValidDate(string date) {
            return Util.IsValidDateTime(date, DateFormat);
        }
    }

    public enum GroupBy {
        date,
        label,
        subaccount,
        country
    }

    public enum Label {
        all
    }

    public enum Subaccount {
        only_main,
        all
    }

    public class AnalyticsParams {
        private string? _end;

        [JsonProperty("end")]
        public string? End {
            get => _end;
            set {
                if (null != value && !Tools.IsValidDate(value)) {
                    throw new ApiException($"Invalid value {value} for param End");
                }

                _end = value;
            }
        }

        [JsonProperty("group_by"), JsonConverter(typeof(StringEnumConverter))]
        public GroupBy? GroupBy { get; set; }

        [JsonProperty("label")] public string? Label { get; set; }
        private string? _start;

        [JsonProperty("start")]
        public string? Start {
            get => _start;
            set {
                if (null != value && !Tools.IsValidDate(value)) {
                    throw new ApiException($"Invalid value {value} for param Start");
                }

                _start = value;
            }
        }

        private string? _subaccounts;

        [JsonProperty("subaccounts")]
        public string? Subaccounts {
            get => _subaccounts;
            set {
                if (null != value
                    && !int.TryParse(value, out _)
                    && !Enum.GetNames(typeof(Subaccount)).Contains(value)) {
                    throw new ApiException($"Invalid value {value} for param Subaccounts");
                }

                _subaccounts = value;
            }
        }
    }

    public class Analytics {
        [JsonProperty("account")] public string? Account { get; private set; }
        [JsonProperty("country")] public string? Country { get; private set; }
        [JsonProperty("date")] public string? Date { get; private set; }
        [JsonProperty("direct")] public int Direct { get; private set; }
        [JsonProperty("economy")] public int Economy { get; private set; }
        [JsonProperty("hlr")] public int Hlr { get; private set; }
        [JsonProperty("inbound")] public int Inbound { get; private set; }
        [JsonProperty("label")] public string? Label { get; private set; }
        [JsonProperty("mnp")] public int Mnp { get; private set; }
        [JsonProperty("voice")] public int Voice { get; private set; }
        [JsonProperty("usage_eur")] public double UsageEur { get; set; }
    }
}