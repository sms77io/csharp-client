using System;
using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Examples {
    class Pricing : BaseExample {
        static async Task RetrieveAllAsCsv() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Format = PricingFormat.csv}));
        }

        static async Task RetrieveCountryGermanyAsCsv() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Country = "de", Format = PricingFormat.csv}));
        }

        static async Task RetrieveAllAsJson() {
            Console.WriteLine(await Client.Pricing());
        }

        static async Task RetrieveCountryGermanyAsJson() {
            Console.WriteLine(await Client.Pricing(new PricingParams {Country = "de"}));
        }
    }
}