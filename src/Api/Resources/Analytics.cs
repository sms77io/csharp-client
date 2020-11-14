using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Analytics;

namespace Sms77.Api.Resources {
    public class Analytics : Resource {
        public const string Endpoint = "analytics";
        
        public async Task<Library.Analytics.Analytics[]> Get(AnalyticsParams? p) {
            return await BaseClient.Fetch<Library.Analytics.Analytics[]>(HttpMethod.Get, Endpoint, p);
        }

        public Analytics(BaseClient baseClient) : base(baseClient) { }
    }
}