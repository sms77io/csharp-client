using System;

namespace Sms77.Api.Library.Analytics {
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
}