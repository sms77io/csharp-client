namespace Sms77.Api.Library {
    public abstract class Resource {
        protected readonly BaseClient BaseClient;

        protected Resource(BaseClient baseClient) {
            BaseClient = baseClient;
        }
    }
}