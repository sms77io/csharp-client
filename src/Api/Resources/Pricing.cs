using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Pricing;

namespace Sms77.Api.Resources {
    public class Pricing : Resource {
        private async Task<T> Get<T>(string? country, PricingFormat? pricingFormat) {
            var args = new PricingParams {Country = country};

            if (null != pricingFormat) {
                args.Format = (PricingFormat) pricingFormat;
            }

            return await BaseClient.Fetch<T>(HttpMethod.Get, Endpoint.Pricing, args);
        }

        public async Task<string> Csv(string? country) {
            return await Get<string>(country, PricingFormat.Csv);
        }

        public async Task<Library.Pricing.Pricing> Json(string? country) {
            return await Get<Library.Pricing.Pricing>(country, null);
        }

        public Pricing(BaseClient baseClient) : base(baseClient) { }
    }
}