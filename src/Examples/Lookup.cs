using System;
using System.Threading.Tasks;
using Sms77.Api.Library.Lookup;
using Sms77.Tests;

namespace Sms77.Examples {
    class Lookup : BaseExample {
        public async Task Cnam() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.Cnam, Number = TestHelper.PhoneNumber}));
        }

        public async Task Format() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.Formatting, Number = TestHelper.PhoneNumber}));
        }

        public async Task Hlr() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.Hlr, Number = TestHelper.PhoneNumber}));
        }

        public async Task MnpAsJson() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.Mnp, Number = TestHelper.PhoneNumber, Json = true}));
        }

        public async Task MnpAsText() {
            Console.WriteLine(await Client.Lookup(
                new LookupParams {Type = LookupType.Mnp, Number = TestHelper.PhoneNumber}));
        }
    }
}