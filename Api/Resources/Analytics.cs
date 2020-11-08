using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Resources {
    public class Analytics : Resource {
        public async Task<Library.Analytics[]> Get(AnalyticsParams? @params = null) {
            return await GetEndpoint<Library.Analytics[]>(Endpoint.Analytics, @params);
        }

        public Analytics(BaseClient baseClient) : base(baseClient) { }
    }
}