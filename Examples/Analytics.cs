using System;
using System.Threading.Tasks;
using Sms77.Api.Library.Analytics;

namespace Sms77.Examples {
    class Analytics : BaseExample {
        static async Task Retrieve() {
            Console.WriteLine(await Client.Analytics(null));
        }

        static async Task RetrieveByNonExistingLabel() {
            Console.WriteLine(await Client.Analytics(new AnalyticsParams {Label = "TestLabel"}));
        }

        static async Task RetrieveByAllSubaccounts() {
            Console.WriteLine(await Client.Analytics(new AnalyticsParams {Subaccounts = "all"}));
        }

        static async Task RetrieveGroupedBy() {
            Console.WriteLine(await Client.Analytics(new AnalyticsParams {GroupBy = GroupBy.label}));

            Console.WriteLine(await Client.Analytics(new AnalyticsParams {GroupBy = GroupBy.subaccount}));

            Console.WriteLine(await Client.Analytics(new AnalyticsParams {GroupBy = GroupBy.country}));
        }

        static async Task RetrieveByTimeFrame() {
            Console.WriteLine(await Client.Analytics(new AnalyticsParams {Start = "label", End = "label"}));
        }
    }
}