using FluentAssertions;
using Name.IntegrationTests;
using NUnit.Framework;

namespace Name.Tests
{
    public class AuthenticationTests : TestBase
    {
        [Test]
        public async void CanAuthenticate()
        {
            var response = await NameApi.Login(ValidLoginRequest);

            response.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
            response.session_token.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public async void CanSignout()
        {
            var logoutResponse = await NameApi.Logout(await GetNewValidSessionToken());
            logoutResponse.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
        }
    }
}