namespace Sms77.Api.Library.ValidateForVoice {
    public static class Tools {
        public static ValidateForVoiceParams DefaultParams(string number) {
            return new ValidateForVoiceParams(number) {
                Callback = null
            };
        }
    }
}