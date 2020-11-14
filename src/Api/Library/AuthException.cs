using System;

namespace Sms77.Api.Library {
    [Serializable]
    public class AuthException : ApiException {
        public AuthException() {
        }

        public AuthException(string message) : base(message) {
        }

        public AuthException(string message, Exception inner) : base(message, inner) {
        }

        // Constructor needed for serialization when an exception propagates from a remoting server to the client.
        protected AuthException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) {
        }
    }
}