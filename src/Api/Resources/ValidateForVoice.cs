using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.ValidateForVoice;
using Model = Sms77.Api.Library.ValidateForVoice.ValidateForVoice;

namespace Sms77.Api.Resources {
    public class ValidateForVoice : Resource {
        public async Task<Model> Post(string number, string? callback = null) {
            return await PostEndpoint<Model>(
                Endpoint.ValidateForVoice,
                new ValidateForVoiceParams {Callback = callback, Number = number});
        }

        public ValidateForVoice(BaseClient baseClient) : base(baseClient) { }
    }
}