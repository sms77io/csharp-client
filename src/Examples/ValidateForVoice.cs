using System;
using System.Threading.Tasks;
using Sms77.Api.Library.ValidateForVoice;
using Sms77.Tests;

namespace Sms77.Examples {
    class ValidateForVoice : BaseExample {
        static async Task Retrieve() {
            var paras = new ValidateForVoiceParams {Callback = "doma.in/cb.php", Number = TestHelper.PhoneNumber};

            Console.WriteLine(await Client.ValidateForVoice(paras));
        }
    }
}