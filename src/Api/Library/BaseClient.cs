using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Sms77.Api.Library {
    public class BaseClient {
        private readonly HttpClient _client;
        public string ApiKey { get; }
        public bool Debug { get; }
        public string SentWith { get; }
        
        public static readonly string ApiKeyEnvironmentKey= "SMS77_API_KEY";
        
        public BaseClient(string apiKey = "", string sentWith = "CSharp", bool debug = false) {
            if ("" == apiKey) {
                apiKey = Environment.GetEnvironmentVariable(ApiKeyEnvironmentKey) ?? string.Empty;
            }
            
            if (string.IsNullOrWhiteSpace(apiKey)) {
                throw new AuthException("Empty API key given");
            }
            
            if (string.IsNullOrWhiteSpace(sentWith)) {
                throw new ApiException("Argument sentWith can not be empty");
            }
            
            ApiKey = apiKey;
            SentWith = sentWith;
            Debug = debug;

            _client = Debug ? new HttpClient(new LoggingHandler(new HttpClientHandler())) : new HttpClient();
            _client.BaseAddress = new Uri("https://gateway.sms77.io/api/");
            _client.DefaultRequestHeaders.Add("Authorization", $"Basic {ApiKey}");
            _client.DefaultRequestHeaders.Add("sentWith", SentWith);
        }

        private NameValueCollection BuildPayload(object? args) {
            var query = HttpUtility.ParseQueryString("");
            
            if (null != args) {
                foreach (var (k, v) in Util.ToObject<JObject>(Util.ToJson(args))) {
                    query.Add(k, Util.ToString(v));
                }
            }

            return query;
        }

        private async Task<string> Post(string endpoint, NameValueCollection query) {
            var body = new List<KeyValuePair<string, string>>();
            var enu = query.GetEnumerator();
            while (enu.MoveNext()) {
                var key = (string) enu.Current;

                body.Add(new KeyValuePair<string, string>(key, query[key]));
            }

            var res = await _client.PostAsync(endpoint, new FormUrlEncodedContent(body));

            res.EnsureSuccessStatusCode();

            return await res.Content.ReadAsStringAsync();
        }
        
        public async Task<T> Fetch<T>(HttpMethod method, string endpoint, object? args, bool throwOnInt = true) {
            var payload = BuildPayload(args);

            dynamic res = HttpMethod.Post == method
                ? await Post(endpoint, payload)
                : await _client.GetStringAsync($"{endpoint}?{payload}");
            
            if (throwOnInt && int.TryParse((string) res, out _)) {
                throw new ApiException("Invalid API-Key or API busy.");
            }

            return typeof(T) == typeof(string) ? res : Util.ToObject<T>(res);
        }
    }
}