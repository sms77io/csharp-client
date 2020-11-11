using System.Threading.Tasks;
using Sms77.Api.Library;
using Sms77.Api.Library.Hooks;
using Analytics = Sms77.Api.Library.Analytics;

namespace Sms77.Api {
    public class Client : BaseClient {
        public Client(string apiKey, string sentWith = "CSharp", bool debug = false) : base(apiKey, sentWith, debug) { }

        public async Task<Analytics[]> Analytics(AnalyticsParams? args) {
            return await new Resources.Analytics(this).Get(args);
        }

        public async Task<double> Balance() {
            return await new Resources.Balance(this).Get();
        }

        public async Task<dynamic> Contacts(ContactsParams args) {
            var resource = new Resources.Contacts(this);

            switch (args.Action) {
                case ContactsAction.read:
                    return await resource.Read(args.Json, args.Id);
                case ContactsAction.write:
                    return await resource.Write(new ContactsWriteParams {
                        Email = args.Email,
                        Empfaenger = args.Empfaenger,
                        Id = args.Id,
                        Json = args.Json,
                        Nick = args.Nick
                    });
            }

            if (args.Id == null) {
                throw new ApiException($"Missing Id for Deletion!");
            }

            return await resource.Delete((ulong) args.Id, args.Json);
        }

        public async Task<dynamic> Hooks(Params args) {
            var resource = new Resources.Hooks(this);

            return args.Action switch {
                Library.Hooks.Action.subscribe => await resource.Subscribe(new SubscribeParams {
                    EventType = (EventType) args.EventType,
                    TargetUrl = args.TargetUrl,
                    RequestMethod = (RequestMethod) args.RequestMethod,
                }),
                Library.Hooks.Action.unsubscribe => await resource.Unsubscribe((int) args.Id),
                _ => await resource.Read()
            };
        }

        public async Task<dynamic> Lookup(LookupParams args) {
            var resource = new Resources.Lookup(this);

            switch (args.Type) {
                case LookupType.format:
                    return await resource.Format(args.Number);
                case LookupType.hlr:
                    return await resource.Hlr(args.Number);
                case LookupType.cnam:
                    return await resource.Cnam(args.Number);
                default:
                    if (true == args.Json) {
                        return await resource.Mnp(args.Number, true);
                    }

                    return await resource.Mnp(args.Number);
            }
        }

        public async Task<dynamic> Pricing(PricingParams? args = null) {
            var resource = new Resources.Pricing(this);

            if (null != args && PricingFormat.csv == args.Format) {
                return await resource.Csv(args.Country);
            }

            return await resource.Json(args?.Country);
        }

        public async Task<dynamic> Sms(SmsParams args) {
            var resource = new Resources.Sms(this);

            if (true == args.Json) {
                return await resource.Json(args);
            }

            return await resource.Text(args);
        }

        public async Task<dynamic> Status(StatusParams args, bool json = false) {
            var resource = new Resources.Status(this);

            return await (json ? (dynamic) resource.Json(args.MsgId) : resource.Text(args.MsgId));
        }

        public async Task<Library.ValidateForVoice> ValidateForVoice(ValidateForVoiceParams args) {
            return await new Resources.ValidateForVoice(this).Post(args.Number, args.Callback);
        }

        public async Task<dynamic> Voice(VoiceParams args, bool json = false) {
            var resource = new Resources.Voice(this);

            return await (json ? (dynamic) resource.Json(args) : resource.Text(args));
        }
    }
}