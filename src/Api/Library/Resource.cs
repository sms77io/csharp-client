using System.Net.Http;
using System.Threading.Tasks;

namespace Sms77.Api.Library {
    public abstract class Resource {
        public readonly BaseClient BaseClient;

        protected Resource(BaseClient baseClient) {
            BaseClient = baseClient;
        }

        protected async Task<T> GetEndpoint<T>(string endpoint, object? args, bool throwOnInt = true) {
            return await Fetch<T>(HttpMethod.Get, endpoint, args, throwOnInt);
        }

        protected async Task<T> PostEndpoint<T>(string endpoint, object? args, bool throwOnInt = true) {
            return await Fetch<T>(HttpMethod.Post, endpoint, args, throwOnInt);
        }

        private async Task<T> Fetch<T>(HttpMethod method, string endpoint, object? args, bool throwOnInt = true) {
            var res = await Util.CallDynamicMethod<dynamic>(BaseClient,
                method == HttpMethod.Get ? "Get" : "Post",
                new[] {endpoint, args, throwOnInt});

            return typeof(T) == typeof(string) ? res : Util.ToObject<T>(res);
        }
    }
}