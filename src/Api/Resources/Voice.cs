using System.Net.Http;
using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Voice;

namespace Sms77.Api.Resources {
    public class Voice : Resource {
        public async Task<string> Post(VoiceParams args) {
            return await BaseClient.Fetch<string>(HttpMethod.Post, Endpoint.Voice, args, false);
        }
        
        public async Task<string> Text(VoiceParams args) {
            return await Post(args);
        }

        public async Task<Library.Voice.Voice> Json(VoiceParams args) {
            var res = await Post(args);

            return new Library.Voice.Voice(res);
        }
        
        public Voice(BaseClient baseClient) : base(baseClient) { }
    }
}