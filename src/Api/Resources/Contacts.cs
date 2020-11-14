using System;
using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Contacts;

namespace Sms77.Api.Resources {
    public class Contacts : Resource {
        public const string Endpoint = "contacts";

        public async Task<dynamic> Read(ReadParams args) {
            const string? endpoint = Endpoint;
            var httpMethod = HttpMethod.Get;
            
            return true == args.Json 
                ?  (dynamic) await BaseClient.Fetch<Contact[]>(httpMethod, endpoint, args)
                :  await BaseClient.Fetch<string>(httpMethod, endpoint, args);
        }

        public async Task<dynamic> Write(WriteParams @params) {
            var res = await BaseClient.Fetch<string>(HttpMethod.Post, Endpoint, @params);

            return true == @params.Json ? (dynamic) Written.FromCsv(res) : res;
        }

        public async Task<dynamic> Delete(DeleteParams args) {
            var res = await BaseClient.Fetch<string>(HttpMethod.Post, Endpoint, args);

            return true == args.Json ? (dynamic) Deleted.FromCsv(res) : Convert.ToUInt16(res);
        }

        public Contacts(BaseClient baseClient) : base(baseClient) { }
    }
}