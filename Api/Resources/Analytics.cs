using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Analytics;

namespace Sms77.Api.Resources {
    public class Analytics : Resource {
        public async Task<Library.Analytics.Analytics[]> Get(AnalyticsParams? p) {
            return await GetEndpoint<Library.Analytics.Analytics[]>(Endpoint.Analytics, p);
        }

        public Analytics(BaseClient baseClient) : base(baseClient) { }
    }
}