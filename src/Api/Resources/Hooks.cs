using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Hooks;

namespace Sms77.Api.Resources {
    public class Hooks : Resource {
        public const string Endpoint = "hooks";

        public async Task<Read> Read() {
            return await BaseClient.Fetch<Read>(HttpMethod.Get, Endpoint, new ReadParams());
        }

        public async Task<Subscription> Subscribe(SubscribeParams @params) {
            return await BaseClient.Fetch<Subscription>(HttpMethod.Post, Endpoint, @params);
        }

        public async Task<Unsubscription> Unsubscribe(int id) {
            return await BaseClient.Fetch<Unsubscription>(
                HttpMethod.Post, Endpoint, new UnsubscribeParams {Id = id});
        }

        public Hooks(BaseClient baseClient) : base(baseClient) { }
    }
}