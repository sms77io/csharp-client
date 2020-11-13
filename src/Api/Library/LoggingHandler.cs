using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Sms77.Api.Library {
    class LoggingHandler : DelegatingHandler {
        public LoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler) {
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken token) {
            Console.WriteLine($"Request: {req}");

            if (null != req.Content) {
                Console.WriteLine(await req.Content.ReadAsStringAsync());
            }

            var res = await base.SendAsync(req, token);

            Console.WriteLine($"Response: {res}");

            if (null != res.Content) {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }

            return res;
        }
    }
}