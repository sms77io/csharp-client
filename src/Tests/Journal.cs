using System.Threading.Tasks;
using NUnit.Framework;
using Sms77.Api.Library;
using Sms77.Api.Library.Journal;
using JournalType = Sms77.Api.Library.Journal.Type;

namespace Sms77.Tests {
    [TestFixture]
    public class Journal {
        private static async Task<T[]> GetAndAssertBaseEntries<T>(JournalParams p) {
            var journals = await BaseTest.Client.Journal(p);

            foreach (BaseJournal j in journals) {
                Assert.That(j.From, Is.Not.Empty);
                Assert.That(j.Id, Is.Not.Empty);
                Assert.That(j.Price, Is.Not.Empty);
                Assert.That(j.Text, Is.Not.Empty);
                Assert.That(j.Timestamp, Is.Not.Empty);
                Assert.That(j.To, Is.Not.Empty);
            }

            return journals;
        }

        [Test]
        public async Task GetAllInbound() {
            await GetAndAssertBaseEntries<JournalInbound>(new JournalParams(JournalType.Inbound));
        }

        [Test]
        public async Task GetAllOutbound() {
            foreach (var j in
                await GetAndAssertBaseEntries<JournalOutbound>(new JournalParams(JournalType.Outbound))) {
                Assert.That(j.Connection, Is.Not.Empty);
                Assert.That(j.Dlr, Is.Null.Or.Not.Empty);
                Assert.That(j.DlrTimestamp, Is.Null.Or.Not.Empty);
                Assert.That(j.Label, Is.Null.Or.Not.Empty);
                Assert.That(j.Latency, Is.Null.Or.Not.Empty);
                Assert.That(j.MccMnc, Is.Null.Or.Not.Empty);
                Assert.That(j.Type, Is.Not.Empty);
            }
        }

        [Test]
        public async Task GetAllVoice() {
            foreach (var j in
                await GetAndAssertBaseEntries<JournalVoice>(new JournalParams(JournalType.Voice))) {
                Assert.That(j.Duration, Is.Not.Empty);
                Assert.That(j.Error, Is.TypeOf<string>());
                Assert.That(j.Status, Is.Not.Empty);
                Assert.That(j.Xml, Is.TypeOf<bool>());
            }
        }

        [Test]
        public async Task GetAllReplies() {
            await GetAndAssertBaseEntries<JournalReplies>(new JournalParams(JournalType.Replies));
        }

        [Test]
        public void RetrieveByWrongTimeFrame() {
            Assert.Throws<ApiException>(() => GetAndAssertBaseEntries<JournalInbound>(
                new JournalParams(JournalType.Inbound) {DateFrom = "ThisShouldNotWork"}));
        }
    }
}