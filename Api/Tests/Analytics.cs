using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Sms77.Api.Library;
using Sms77.Api.Library.Analytics;

namespace Sms77.Api.Tests {
    [TestFixture]
    public class Analytics {
        private static void AssertEntries(Library.Analytics.Analytics[] analytics) {
            foreach (var a in analytics) {
                Assert.That(a.Date, Is.Not.Empty);
                Assert.That(a.Economy, Is.Not.Negative);
                Assert.That(a.Direct, Is.Not.Negative);
                Assert.That(a.Voice, Is.Not.Negative);
                Assert.That(a.Hlr, Is.Not.Negative);
                Assert.That(a.Mnp, Is.Not.Negative);
                Assert.That(a.Inbound, Is.Not.Negative);
                Assert.That(a.UsageEur, Is.Not.Negative);
            }
        }

        [Test]
        public async Task RetrieveAll() {
            AssertEntries(await BaseTest.Client.Analytics(null));
        }

        [Test]
        public async Task RetrieveByNonExistingLabel() {
            // API returns all messages if label was not found

            var analytics = await BaseTest.Client.Analytics(
                new AnalyticsParams {Label = "TestLabel"});

            AssertEntries(analytics);
        }

        [Test]
        public async Task RetrieveByAllSubaccounts() {
            AssertEntries(await BaseTest.Client.Analytics(
                new AnalyticsParams {Subaccounts = "all"}));
        }

        [Test]
        public async Task RetrieveGroupedBy() {
            foreach (var groupBy in Enum.GetValues(typeof(GroupBy)).Cast<GroupBy>()) {
                AssertEntries(await BaseTest.Client.Analytics(
                    new AnalyticsParams {GroupBy = groupBy}));
            }
        }

        [Test]
        public async Task RetrieveByTimeFrame() {
            var entries = await BaseTest.Client.Analytics(
                new AnalyticsParams {Start = "2020-07-01", End = "2020-07-31"});

            Assert.That(entries.Length, Is.EqualTo(31));
            
            AssertEntries(entries);
        }

        [Test]
        public void RetrieveByWrongSubaccounts() {
            Assert.Throws<ApiException>(() => BaseTest.Client.Analytics(
                new AnalyticsParams {Subaccounts = "ExpectsANameOfSms77.Api.Library.Analytics.SubaccountsOrInt"}));
        }
    }
}