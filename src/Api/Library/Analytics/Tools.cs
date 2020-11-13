using System;

namespace Sms77.Api.Library.Analytics {
    public static class Tools {
        public static AnalyticsParams DefaultParams = new AnalyticsParams {
            End = DateTime.Today.ToString(DateFormat),
            GroupBy = GroupBy.Date,
            Label = Enum.GetName(typeof(Label), Label.All),
            Start = DateTime.Today.AddDays(-30).ToString(DateFormat),
            Subaccounts = Enum.GetName(typeof(Subaccount), Subaccount.OnlyMain)
        };

        private const string DateFormat = "yyyy-M-d";

        public static bool IsValidDate(string date) {
            return Util.IsValidDateTime(date, DateFormat);
        }
    }
}