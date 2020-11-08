using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Sms77.Api.Library {
    public class BaseClient {
        private readonly Dictionary<string, string> _commonPayload = new Dictionary<string, string>();
        protected readonly string ApiKey;
        protected readonly HttpClient Client;
        protected readonly bool Debug;
        protected readonly string SentWith;

        public BaseClient(string apiKey, string sentWith = "CSharp", bool debug = false) {
            ApiKey = apiKey;
            SentWith = sentWith;
            Debug = debug;

            Client = Debug ? new HttpClient(new LoggingHandler(new HttpClientHandler())) : new HttpClient();
            Client.BaseAddress = new Uri("https://gateway.sms77.io/api/");

            _commonPayload.Add("p", ApiKey);
            _commonPayload.Add("sentWith", SentWith);
        }

        public void ThrowOnInteger(string response) {
            if (int.TryParse(response, out _)) {
                throw new ApiException("Invalid API-Key or API busy.");
            }
        }

        public async Task<dynamic> Get(string endpoint, object @params = null, bool throwOnInt = false) {
            var query = BuildQueryString(@params);

            var response = await Client.GetStringAsync($"{endpoint}?{query}");

            if (throwOnInt) {
                ThrowOnInteger(response);
            }

            return response;
        }

        private NameValueCollection BuildQueryString(object args) {
            var query = HttpUtility.ParseQueryString("");

            foreach (var (key, value) in _commonPayload) {
                query.Add(key, value);
            }

            if (null != args) {
                foreach (var (key, value) in Util.ToObject<JObject>(Util.ToJson(args))) {
                    query.Add(key, Util.ToString(value));
                }
            }

            return query;
        }

        public async Task<dynamic> Post(string endpoint, object @params = null, bool throwOnInt = false) {
            var query = BuildQueryString(@params);
            var body = new List<KeyValuePair<string, string>>();
            var enu = query.GetEnumerator();
            while (enu.MoveNext()) {
                var key = (string) enu.Current;

                body.Add(new KeyValuePair<string, string>(key, query[key]));
            }

            var response = await Client.PostAsync(endpoint, new FormUrlEncodedContent(body));

            response.EnsureSuccessStatusCode();

            var str = await response.Content.ReadAsStringAsync();

            if (throwOnInt) {
                ThrowOnInteger(str);
            }

            return str;
        }
    }
}