using FluentAssertions;
using Name.IntegrationTests;
using NUnit.Framework;

namespace Name.Tests
{
    [TestFixture]
    public class GeneralTests : TestBase
    {
        [Test]
        public async void UnitTestsAreConfiguredToUseTheTestingApi()
        {
            var response = await NameApi.Hello();

            response.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
            response.service.Should().Contain("Test Server");
        }
    }
}