namespace ReferralManagement.Services
{
    public class ApiConfigurationService : IApiConfigurationService
    {
        private readonly IConfiguration _config;

        public ApiConfigurationService(IConfiguration config)
        {
            _config = config;
        }

        public string GetBaseUri()
        {
            return _config.GetValue<string>("API:BaseUri");
        }
    }
}
