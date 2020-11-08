using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Resources {
    public class Pricing : Resource {
        private async Task<T> Get<T>(string? country, PricingFormat? pricingFormat) {
            var args = new PricingParams {Country = country};

            if (null != pricingFormat) {
                args.Format = (PricingFormat) pricingFormat;
            }

            return await GetEndpoint<T>(Endpoint.Pricing, args);
        }

        public async Task<string> Csv(string? country) {
            return await Get<string>(country, PricingFormat.csv);
        }

        public async Task<Library.Pricing> Json(string? country) {
            return await Get<Library.Pricing>(country, null);
        }

        public Pricing(BaseClient baseClient) : base(baseClient) { }
    }
}