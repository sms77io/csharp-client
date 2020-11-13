using System;
using System.Threading.Tasks;
using Sms77.Api.Tests;
using Sms77.Api.Library;
using Sms77.Api.Library.ValidateForVoice;

namespace Sms77.Api.Examples {
    class ValidateForVoice : BaseExample {
        static async Task Retrieve() {
            var paras = new ValidateForVoiceParams {Callback = "doma.in/cb.php", Number = TestHelper.PhoneNumber};

            Console.WriteLine(await Client.ValidateForVoice(paras));
        }
    }
}