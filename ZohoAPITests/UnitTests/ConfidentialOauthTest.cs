using Microsoft.Extensions.Configuration;
using ZohoAPI;

namespace ZohoAPITests.UnitTests
{
    [TestFixture]
    public class AccessTokenUnitTests
    {
        private readonly IConfigurationRoot config;
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? OrgId { get; set; }

        public AccessTokenUnitTests()
        {
            config = new ConfigurationBuilder()
               .AddUserSecrets<AccessTokenUnitTests>()
               .Build();

            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
            OrgId = config["orgId"];
        }

        [Test]
        public void GetWithValidCredentials()
        {
            var accessToken = new ConfidentialOauth(ClientId!, ClientSecret!, OrgId!);
            Assert.DoesNotThrowAsync(async () => await accessToken.Get());
        }

        //[Test]
        //public void GetWithInvalidCredentials()
        //{
        //    // Should output status 200 ok but with error json
        //    string invalidId = "invalid";
        //    string invalidSecret = "invalid";
        //    string invalidOrgId = "invalid";

        //    var accessToken = new ConfidentialOauth(invalidId, invalidSecret, invalidOrgId);
        //    Assert.ThrowsAsync<Exception>(async () => await accessToken.Get());
        //}
    }
}
