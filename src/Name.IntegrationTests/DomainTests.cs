using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Name.IntegrationTests
{
    [TestFixture]
    public class DomainTests : TestBase
    {
        [Test]
        public async void CanCheckDomainAvailability()
        {
            var request = new CheckDomainAvailabilityRequest()
            {
                keyword = "example",
                services = "availability",
                tlds = new List<string>() { "com"}
            };
            var response = await NameApi.CheckDomainAvailability(request, await GetNewValidSessionToken());
            response.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
        }

        [Test]
        public async void CanCreateDomain()
        {
            var request = new CreateDomainRequest()
            {
                domain_name = "testdomain1.com",
                period = 1,
                nameservers = new List<string>() { "ns1.ghuntley.com", "ns2.ghuntley.com"},
                contacts = new List<DomainContact>()
                {
                    new DomainContact()
                    {
                        address_1 = "Test",
                        address_2 = "Test",
                        city = "Test",
                        country = "Australia",
                        email = "ghuntley@ghuntley.com",
                        fax = "411",
                        first_name = "Geoffrey",
                        last_name = "Huntley",
                        organization = "Geoffrey Huntley",
                        phone = "411",
                        type = new List<DomainContactType>()
                        {
                            DomainContactType.Administrative,
                            DomainContactType.Billing,
                            DomainContactType.Registrant,
                            DomainContactType.Technical
                        }
                    }
                }
            };
            var response = await NameApi.CreateDomain(request, await GetNewValidSessionToken());
            response.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
        }

        [Test]
        public async void CanListDomains()
        {
            var response = await NameApi.ListDomains(await GetNewValidSessionToken());
            response.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
        }

        [Test]
        public async void CanLockDomain()
        {
            const string domain = "example.com";
            var response = await NameApi.LockDomain(domain, await GetNewValidSessionToken());
            response.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
        }

        [Test]
        public async void CanRetrieveDomain()
        {
            throw new NotImplementedException();
        }

        [Test]
        public async void CanUnlockDomain()
        {
            const string domain = "example.com";
            var response = await NameApi.UnlockDomain(domain, await GetNewValidSessionToken());
            response.Result.Code.Should().Be(ResponseCode.CommandSuccessful);
        }
    }
}