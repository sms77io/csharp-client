using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Hooks;

namespace Sms77.Api.Resources {
    public class Hooks : Resource {
        public async Task<Read> Read() {
            return await GetEndpoint<Read>(Endpoint.Hooks, new ReadParams());
        }

        public async Task<Subscription> Subscribe(SubscribeParams @params) {
            return await PostEndpoint<Subscription>(Endpoint.Hooks, @params);
        }

        public async Task<Unsubscription> Unsubscribe(int id) {
            return await PostEndpoint<Unsubscription>(Endpoint.Hooks, new UnsubscribeParams {Id = id});
        }

        public Hooks(BaseClient baseClient) : base(baseClient) { }
    }
}