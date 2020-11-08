using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Resources {
    public class Sms : Resource {
        private async Task<T> Request<T>(SmsParams smsParams) {
            return await PostEndpoint<T>(
                Endpoint.Sms, smsParams, !(true != smsParams.Details && true != smsParams.Json));
        }

        public async Task<string> Text(SmsParams smsParams) {
            return await Request<string>(smsParams);
        }

        public async Task<Library.Sms> Json(SmsParams smsParams) {
            return await Request<Library.Sms>(smsParams);
        }

        public Sms(BaseClient baseClient) : base(baseClient) { }
    }
}