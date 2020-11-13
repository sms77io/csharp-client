using System;
using System.Threading.Tasks;
using Sms77.Api.Library.Pricing;

namespace Sms77.Examples {
    class Pricing : BaseExample {
        static async Task RetrieveAllAsCsv() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Format = PricingFormat.Csv}));
        }

        static async Task RetrieveCountryGermanyAsCsv() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Country = "de", Format = PricingFormat.Csv}));
        }

        static async Task RetrieveAllAsJson() {
            Console.WriteLine(await Client.Pricing());
        }

        static async Task RetrieveCountryGermanyAsJson() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Country = "de"}));
        }
    }
}