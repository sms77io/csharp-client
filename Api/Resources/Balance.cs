using System;
using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Resources {
    public class Balance : Resource {
        public async Task<double> Get() {
            var response = await BaseClient.Get(Endpoint.Balance);

            if (int.TryParse(response, out int _)) {
                throw new ApiException("Invalid API-Key or API busy.");
            }

            return Convert.ToDouble(response);
        }

        public Balance(BaseClient baseClient) : base(baseClient) {
            
        }
    }
}