using System;

namespace Sms77.Api.Library.Journal {
    public static class Tools {
        public static JournalParams DefaultParams(Type type) {
            return new JournalParams(type);
        }

        public static bool IsValidDate(string date) {
            return Util.IsValidDateTime(date, "yyyy-M-d");
        }
    }
}