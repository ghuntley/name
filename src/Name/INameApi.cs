using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;

namespace Name
{
    public interface INameApi
    {
        [Post("/api/domain/check")]
        Task<CheckDomainAvailabilityResponse> CheckDomainAvailability(
            CheckDomainAvailabilityRequest checkDomainAvailabilityRequest,
            [Header("Api-Session-Token")] string sessionToken);


        [Post("/api/domain/create")]
        Task<CreateDomainResponse> CreateDomain(
            CreateDomainRequest createDomainRequest,
            [Header("Api-Session-Token")] string sessionToken);

        [Get("/api/hello")]
        Task<HelloResponse> Hello();

        [Get("/api/domain/list")]
        Task<ListDomainsResponse> ListDomains([Header("Api-Session-Token")] string sessionToken);

        [Post("/api/domain/lock/{domainName}")]
        Task<LockDomainResponse> LockDomain(string domainName, [Header("Api-Session-Token")] string sessionToken);

        [Post("/api/login")]
        Task<LoginResponse> Login([Body] LoginRequest loginRequest);

        [Get("/api/logout")]
        Task<LoginResponse> Logout([Header("Api-Session-Token")] string sessionToken);

        [Get("/api/account/get")]
        Task<RetrieveAccountResponse> RetrieveAccount([Header("Api-Session-Token")] string sessionToken);

        [Post("/api/domain/unlock/{domainName}")]
        Task<UnlockDomainResponse> UnlockDomain(string domainName, [Header("Api-Session-Token")] string sessionToken);
    }

    public interface INameApiService
    {
        INameApi ApiClient { get; }
    }

    public class NameApiService : INameApiService

    {
        public const string DefaultApiBaseAddress = "https://api.name.com";

        private readonly Lazy<INameApi> _client;

        public NameApiService(string apiBaseAddress = null)
        {
            _client =
                new Lazy<INameApi>(
                    () =>
                        RestService.For<INameApi>(apiBaseAddress ?? DefaultApiBaseAddress,
                            new RefitSettings()
                            {
                                JsonSerializerSettings =
                                    new JsonSerializerSettings()
                                    {
                                        Converters =
                                        {
                                            new ListDomainsJsonConverter(),
                                            new CheckDomainAvailabilityJsonConverter()
                                        }
                                    }
                            }));
        }

        public INameApi ApiClient
        {
            get { return _client.Value; }
        }
    }
}