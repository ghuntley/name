using System.Threading.Tasks;
using Conditions;
using Newtonsoft.Json;
using Refit;

namespace Name.IntegrationTests
{
    public class TestBase
    {
        public TestBase()
        {
            JsonConvert.DefaultSettings =
    () => new JsonSerializerSettings
    {
        Converters = { new ListDomainsJsonConverter() }
    };

            ApiBaseUrl = AppSettings.ApiBaseUrl;
            //Condition.Requires(ApiBaseUrl, "apiBaseUrl").IsNotNullOrEmpty();
            //Condition.Requires(ApiBaseUrl, "apiBaseUrl must not be production").Contains(".dev.");

            ApiToken = AppSettings.ApiToken;
            Condition.Requires(ApiToken, "apiToken").IsNotNullOrEmpty();

            Username = AppSettings.Username;
            Condition.Requires(Username, "username").IsNotNullOrEmpty();

            NameApi = RestService.For<INameApi>(ApiBaseUrl);
            Condition.Requires(NameApi, "nameApi").IsNotNull();

            ValidLoginRequest = new LoginRequest
            {
                api_token = ApiToken,
                username = Username
            };
            Condition.Requires(ValidLoginRequest, "loginRequest").IsNotNull();
        }

        public string ApiBaseUrl { get; private set; }
        public string ApiToken { get; private set; }
        public INameApi NameApi { get; private set; }
        public string Username { get; private set; }
        public LoginRequest ValidLoginRequest { get; private set; }

        public async Task<string> GetNewValidSessionToken()
        {
            var loginResponse = await NameApi.Login(ValidLoginRequest);

            Condition.Requires(loginResponse.session_token, "sessionToken").IsNotNullOrEmpty();
            return loginResponse.session_token;
        }
    }
}