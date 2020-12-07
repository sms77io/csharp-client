![Sms77.io Logo](https://www.sms77.io/wp-content/uploads/2019/07/sms77-Logo-400x79.png "sms77")

# C# API Client for the Sms77.io SMS Gateway

## Installation

```
dotnet add package sms77-api
```

### Example

```c#
using System;
using System.Threading.Tasks;
using Client = Sms77.Api.Client;

class Program
{
    static async Task Main()
    {
        Environment.SetEnvironmentVariable(
        Client.ApiKeyEnvironmentKey, "MySuperSecretApiKey!");
        var balance = await new Client().Balance();
        Console.WriteLine($"Current account balance: {balance}");
    }
}
```