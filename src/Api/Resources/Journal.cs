using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Journal;

namespace Sms77.Api.Resources {
    public class Journal : Resource {
        public const string Endpoint = "journal";

        public async Task<T[]> Get<T>(JournalParams p) {
            return await BaseClient.Fetch<T[]>(HttpMethod.Get, Endpoint, p);
        }

        public Journal(BaseClient baseClient) : base(baseClient) { }
    }
}