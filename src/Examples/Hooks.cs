using System;
using System.Threading.Tasks;
using Sms77.Api.Library.Hooks;
using Action = Sms77.Api.Library.Hooks.Action;

namespace Sms77.Examples {
    class Hooks : BaseExample {
        static async Task Read() {
            Read read = await Client.Hooks(new Params {Action = Action.Read});

            if (!read.Success) {
                Console.WriteLine("Failed to retrieve hooks");

                return;
            }

            Console.WriteLine($"Retrieved {read.Entries.Length} hooks");

            foreach (var entry in read.Entries) {
                Console.WriteLine($"Hook #{entry.Id}:");
                Console.WriteLine($"TargetUrl: {entry.TargetUrl}");
                Console.WriteLine($"EventType: {entry.EventType}");
                Console.WriteLine($"RequestMethod: {entry.RequestMethod}");
                Console.WriteLine($"Created: {entry.Created}");
            }
        }

        static async Task SubscribeSmsStatusPost() {
            await Subscription(EventType.SmsStatusUpdate);
        }

        static async Task SubscribeInboundSmsPost() {
            await Subscription(EventType.NewInboundSms);
        }

        static async Task SubscribeVoiceStatusPost() {
            await Subscription(EventType.VoiceStatusUpdate);
        }

        static async Task SubscribeSmsStatusGet() {
            await Subscription(EventType.SmsStatusUpdate, RequestMethod.Get);
        }

        static async Task SubscribeInboundSmsGet() {
            await Subscription(EventType.NewInboundSms, RequestMethod.Get);
        }

        static async Task SubscribeVoiceStatusGet() {
            await Subscription(EventType.VoiceStatusUpdate, RequestMethod.Get);
        }

        static async Task Unsubscribe(int id = 0) {
            if (0 == id) {
                var subscribed = await Subscription(EventType.SmsStatusUpdate);

                id = subscribed.Id;
            }

            await Unsubscription(id);
        }

        static async Task<Subscription> Subscription(
            EventType eventType,
            RequestMethod requestMethod = RequestMethod.Post) {
            var targetUrl = "http://my.tld/" + Guid.NewGuid();

            Subscription subscribed = await Client.Hooks(new Params {
                Action = Action.Subscribe,
                EventType = eventType,
                RequestMethod = requestMethod,
                TargetUrl = targetUrl
            });

            if (subscribed.Success) {
                Console.WriteLine("Created subscription:");
                Console.WriteLine("ID: " + subscribed.Id);
                Console.WriteLine("EventType: " + eventType);
                Console.WriteLine("RequestMethod: " + requestMethod);
                Console.WriteLine("TargetUrl: " + targetUrl);
            }
            else {
                Console.WriteLine("Failed to create subscription");
            }

            await Unsubscription(subscribed.Id);

            return subscribed;
        }

        static async Task Unsubscription(int id) {
            Unsubscription unsubscribed = await Client.Hooks(new Params {
                Action = Action.Unsubscribe,
                Id = id
            });

            Console.WriteLine(unsubscribed.Success
                ? $"Unsubscribed hook with ID {id}"
                : $"Failed to unsubscribe hook with ID {id}");
        }
    }
}