using System.Threading.Tasks;
using Sms77.Api.Library;

namespace Sms77.Api.Resources {
    public class Voice : Resource {
        public async Task<string> Post(VoiceParams args) {
            return await PostEndpoint<string>(Endpoint.Voice, args, false);
        }
        
        public async Task<string> Text(VoiceParams args) {
            return await Post(args);
        }

        public async Task<Library.Voice> Json(VoiceParams args) {
            var res = await Post(args);

            return new Library.Voice(res);
        }
        
        public Voice(BaseClient baseClient) : base(baseClient) { }
    }
}