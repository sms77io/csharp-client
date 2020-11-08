using System.Threading.Tasks;
using Newtonsoft.Json;
using Sms77.Api.Library;

namespace Sms77.Api.Resources {
    public class Lookup : Resource {
        private async Task<T> Request<T>(object args) {
            return await PostEndpoint<T>(Endpoint.Lookup, args);
        }

        public async Task<CnamLookup> Cnam(string number) {
            return await Request<CnamLookup>(new LookupCnamParams {Number = number});
        }

        public async Task<FormatLookup> Format(string number) {
            return await Request<FormatLookup>(new LookupFormatParams {Number = number});
        }

        public async Task<HlrLookup> Hlr(string number) {
            return await Request<HlrLookup>(new LookupHlrParams {Number = number});
        }

        public async Task<string> Mnp(string number) {
            return await Request<string>(new LookupMnpParams {Number = number});
        }

        public async Task<MnpLookup> Mnp(string number, bool json) {
            _ = json;

            return await Request<MnpLookup>(new LookupMnpParams {Number = number, Json = true});
        }

        public Lookup(BaseClient baseClient) : base(baseClient) { }
    }
}