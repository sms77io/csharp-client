using System;
using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Resources {
    public class Contacts : Resource {
        public async Task<dynamic> Read(bool json = false, ulong? id = null) {
            var args = new ContactsReadParams {Id = id, Json = json};
            var endpoint = Endpoint.Contacts;
            
            return json 
                ?  (dynamic) await GetEndpoint<Contact[]>(endpoint, args)
                :  await GetEndpoint<string>(endpoint, args);
        }

        public async Task<dynamic> Write(ContactsWriteParams @params) {
            var res = await BaseClient.Post(Endpoint.Contacts, @params, true);

            return @params.Json ? WriteContact.FromCsv(res) : res;
        }

        public async Task<dynamic> Delete(ulong id, bool json = false) {
            var args = new ContactsDeleteParams {Id = id, Json = json};
            var res = await BaseClient.Post(Endpoint.Contacts, args);

            return json ? DelContact.FromCsv(res) : Convert.ToUInt16(res);
        }

        public Contacts(BaseClient baseClient) : base(baseClient) { }
    }
}