using System;
using System.Threading.Tasks;

namespace Sms77.Examples {
    class Balance : BaseExample {
        static async Task Retrieve() {
            Console.WriteLine(await Client.Balance());
        }
    }
}