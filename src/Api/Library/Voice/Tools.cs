namespace Sms77.Api.Library.Voice {
    public static class Tools {
        public static VoiceParams DefaultParams(string to, string text) {
            return new VoiceParams(to, text) {
                From = null,
                Xml = false
            };
        }
    }
}