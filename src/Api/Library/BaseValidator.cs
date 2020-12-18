using System;
using System.Text.RegularExpressions;

namespace Sms77.Api.Library {
    public abstract class BaseValidator<T> {
        public bool Invalid;
        protected T Value;
        protected readonly bool Required;
        
        protected BaseValidator(T value, bool required) {
            Value = value;
            Required = required;

            if (Required) {
                Invalid = null == value;
            }
        }

        public virtual bool Validate() {
            throw new NotImplementedException();
        }
    }
    
    public class IntValidator : BaseValidator<int?> {
        public bool MinMismatch;
        public bool MaxMismatch;
        private readonly uint? _max;
        private readonly uint? _min;

        protected IntValidator(int? value, bool required, uint? min, uint? max) : base(value, required) {
            _min = min;
            _max = max;
        }

        public override bool Validate() {
            CheckMin();
            CheckMax();

            return !Invalid;
        }

        private void CheckMax() {
            if (null != _max) {
                MaxMismatch = Value > _max;

                if (!Invalid) {
                    Invalid = MaxMismatch;
                }
            }
        }
        
        private void CheckMin() {
            if (null != _min) {
                MinMismatch = Value < _min;
                
                if (!Invalid) {
                    Invalid = MinMismatch;
                }
            }
        }
    }
    
    public class StringValidator : BaseValidator<string?> {
        public bool MaxLengthMismatch;
        public bool RegexMismatch;
        private readonly uint? _maxLength;
        private readonly Regex? _regex;

        protected StringValidator(string? value, bool required, uint? maxLength, Regex? regex) : base(value, required) {
            _maxLength = maxLength;
            _regex = regex;

            if (Required) {
                Invalid = string.IsNullOrEmpty(Value);
            }
        }

        public override bool Validate() {
            if (null != Value) {
                CheckMaxLength();
                CheckPattern();
            }

            return !Invalid;
        }

        private void CheckMaxLength() {
            if (null != _maxLength) {
                MaxLengthMismatch = Value.Length > _maxLength;

                if (!Invalid) {
                    Invalid = MaxLengthMismatch;
                }
            }
        }

        private void CheckPattern() {
            if (null != _regex) {
                RegexMismatch = Value.Length != _regex.Matches(Value).Count;

                if (!Invalid) {
                    Invalid = RegexMismatch;
                }
            }
        }
    }
}