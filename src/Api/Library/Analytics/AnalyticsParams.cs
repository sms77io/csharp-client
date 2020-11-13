using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Sms77.Api.Library.Analytics {
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
}