using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Name.IntegrationTests
{
    public class AccountTests : TestBase
    {
        [Test]
        public async void CanRetrieveAccount()
        {
            var loginResponse = await NameApi.Login(ValidLoginRequest);
            loginResponse.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
            
            var retrieveAccountResponse = await NameApi.RetrieveAccount(loginResponse.session_token);
            retrieveAccountResponse.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
            retrieveAccountResponse.username.Should().Be(Username);
            retrieveAccountResponse.account_credit.Should().NotBe(0);
            retrieveAccountResponse.contacts.Count.Should().Be(1);
        }
    }
}
