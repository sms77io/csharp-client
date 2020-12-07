namespace Sms77.Api.Library.Journal {
    public class JournalInbound : BaseJournal {
        public JournalInbound(string from, string id, string price, string text, string timestamp, string to) 
            : base(from, id, price, text, timestamp, to) { }
    }
}