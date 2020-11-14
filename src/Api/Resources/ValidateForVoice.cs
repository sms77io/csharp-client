using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.ValidateForVoice;
using Model = Sms77.Api.Library.ValidateForVoice.ValidateForVoice;

namespace Sms77.Api.Resources {
    public class ValidateForVoice : Resource {
        public const string Endpoint = "validate_for_voice";

        public async Task<Model> Post(string number, string? callback = null) {
            return await BaseClient.Fetch<Model>(HttpMethod.Post,
                Endpoint,
                new ValidateForVoiceParams(number) {Callback = callback});
        }

        public ValidateForVoice(BaseClient baseClient) : base(baseClient) { }
    }
}