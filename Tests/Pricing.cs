using System.Threading.Tasks;
using NUnit.Framework;
using Sms77.Api.Library.Pricing;

namespace Sms77.Tests {
    [TestFixture]
    public class Pricing {
        [Test]
        public async Task TestPricingGlobalCsv() {
            string pricing = await BaseTest.Client.Pricing(new PricingParams {Format = PricingFormat.csv});

            Assert.That(pricing, Is.Not.Empty);
        }

        [Test]
        public async Task TestPricingGlobalJson() {
            Api.Library.Pricing.Pricing pricing = await BaseTest.Client.Pricing();

            Assert.That(pricing, Is.InstanceOf(typeof(Api.Library.Pricing.Pricing)));
            Assert.That(pricing.CountCountries, Is.Positive);
        }

        [Test]
        public async Task TestPricingGermanyCsv() {
            string pricing
                = await BaseTest.Client.Pricing(new PricingParams {Country = "de", Format = PricingFormat.csv});

            Assert.That(pricing, Is.Not.Empty);
        }

        [Test]
        public async Task TestPricingGermanyJson() {
            Api.Library.Pricing.Pricing pricing = await BaseTest.Client.Pricing(
                new PricingParams {Country = "de"});

            Assert.That(pricing, Is.InstanceOf(typeof(Api.Library.Pricing.Pricing)));
            Assert.That(pricing.CountCountries, Is.EqualTo(1));
        }
    }
}