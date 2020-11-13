using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Status;

namespace Sms77.Api.Resources {
    public class Status : Resource {
        private async Task<string> Request(ulong id) {
            return await GetEndpoint<string>(Endpoint.Status, new StatusParams(id));
        }

        public async Task<string> Text(ulong id) {
            return await Request(id);
        }

        public async Task<Library.Status.Status> Json(ulong id) {
            return Library.Status.Status.FromString(await Request(id));
        }

        public Status(BaseClient baseClient) : base(baseClient) { }
    }
}