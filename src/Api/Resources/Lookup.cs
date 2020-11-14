using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Lookup;

namespace Sms77.Api.Resources {
    public class Lookup : Resource {
        public const string Endpoint = "lookup";

        private async Task<T> Request<T>(object args) {
            return await BaseClient.Fetch<T>(HttpMethod.Post, Endpoint, args);
        }

        public async Task<CnamLookup> Cnam(string number) {
            return await Request<CnamLookup>(new CnamParams {Number = number});
        }

        public async Task<FormatLookup> Format(string number) {
            return await Request<FormatLookup>(new FormatParams {Number = number});
        }

        public async Task<HlrLookup> Hlr(string number) {
            return await Request<HlrLookup>(new HlrParams {Number = number});
        }

        public async Task<string> Mnp(string number) {
            return await Request<string>(new MnpParams {Number = number});
        }

        public async Task<MnpLookup> Mnp(string number, bool json) {
            _ = json;

            return await Request<MnpLookup>(new MnpParams {Number = number, Json = true});
        }

        public Lookup(BaseClient baseClient) : base(baseClient) { }
    }
}