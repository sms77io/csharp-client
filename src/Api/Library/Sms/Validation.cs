using System;
using System.Text.RegularExpressions;

namespace Sms77.Api.Library.Sms {
    public class Validator {
        public readonly Delay Delay;
        public readonly ForeignId ForeignId;
        public readonly From From;
        public readonly Label Label;
        public readonly Text Text;
        public readonly To To;
        public readonly Ttl Ttl;

        public readonly bool Valid;

        public Validator(SmsParams p) {
            Delay = new Delay(p);
            ForeignId = new ForeignId(p);
            From = new From(p);
            Label = new Label(p);
            Text = new Text(p);
            To = new To(p);
            Ttl = new Ttl(p);

            Valid = Delay.Validate() 
                    && ForeignId.Validate() 
                    && From.Validate()
                    && Label.Validate()
                    && Text.Validate()
                    && To.Validate()
                    && Ttl.Validate();
        }
    }

    public class Delay : StringValidator {
        public static readonly Regex Regex =
            new Regex(@"[\d]{4}-(0[1-9]|1[0-2])-(0[1-9]|[1-2][\d]|3[0-1]) (2[0-3]|[01][\d]):[0-5][\d]");

        public bool TimestampMismatch;

        public Delay(SmsParams p) : base(p.Delay, false, null, Regex) { }

        public override bool Validate() {
            if (null != Value) {
                try {
                    new DateTime(1970, 1, 1, 0, 0, 0, 0)
                        .AddMilliseconds(Convert.ToDouble(Value));

                    TimestampMismatch = false;
                }
                catch {
                    TimestampMismatch = true;
                }
            }
            
            Invalid = TimestampMismatch;

            return Invalid ? base.Validate() : !Invalid;
        }
    }

    public class ForeignId : StringValidator {
        public const int MaxLength = 64;
        public static readonly Regex Regex = new Regex(@"[0-9a-z-@_.\\]", RegexOptions.IgnoreCase);

        public ForeignId(SmsParams p) :
            base(p.ForeignId, false, MaxLength, Regex) { }
    }
    
    public class From : StringValidator {
        public const uint MaxLengthAlphaNumeric = 11;
        public const uint MaxLengthNumeric = 16;

        public From(SmsParams p) :
            base(p.From, false,
                uint.TryParse(p.From, out _) ? MaxLengthNumeric : MaxLengthAlphaNumeric, null) { }
    }

    public class Label : StringValidator {
        public const int MaxLength = 100;
        public static readonly Regex Regex = new Regex(@"[0-9a-z-@_.\\]", RegexOptions.IgnoreCase);

        public Label(SmsParams p) :
            base(p.Label, false, MaxLength, Regex) { }
    }
    
    public class Text : StringValidator {
        public const int MaxLength = 1520;

        public Text(SmsParams p) :
            base(p.Text, true, MaxLength, null) { }
    }

    public class To : StringValidator {
        public To(SmsParams p) :
            base(p.To, true, null, null) { }
    }

    public class Ttl : IntValidator {
        public const int Min = 1;
        public const int Max = int.MaxValue;

        public Ttl(SmsParams p) :
            base(p.Ttl, false, Min, Max) { }
    }
}