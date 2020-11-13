using System;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Contacts;

namespace Sms77.Api.Resources {
    public class Contacts : Resource {
        public async Task<dynamic> Read(ReadParams args) {
            var endpoint = Endpoint.Contacts;
            
            return true == args.Json 
                ?  (dynamic) await GetEndpoint<Contact[]>(endpoint, args)
                :  await GetEndpoint<string>(endpoint, args);
        }

        public async Task<dynamic> Write(WriteParams @params) {
            var res = await BaseClient.Post(Endpoint.Contacts, @params, true);

            return true == @params.Json ? Written.FromCsv(res) : res;
        }

        public async Task<dynamic> Delete(DeleteParams args) {
            var res = await BaseClient.Post(Endpoint.Contacts, args);

            return true == args.Json ? Deleted.FromCsv(res) : Convert.ToUInt16(res);
        }

        public Contacts(BaseClient baseClient) : base(baseClient) { }
    }
}