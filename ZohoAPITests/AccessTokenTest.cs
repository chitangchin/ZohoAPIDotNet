using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.Configuration;
using ZohoAPI;

namespace ZohoAPITests
{
    [TestFixture]
    public class AccessTokenIntegrationTests
    {
        private IConfigurationRoot config;
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? OrgId { get; set; }

        public AccessTokenIntegrationTests()
        {
            config = new ConfigurationBuilder()
               .AddUserSecrets<AccessTokenIntegrationTests>()
               .Build();

            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
            OrgId = config["orgId"];
        }

        [Test]
        public void GetWithValidCredentials()
        {
            var accessToken = new AccessToken(ClientId!, ClientSecret!, OrgId!);
            Assert.DoesNotThrowAsync(async () => await accessToken.Get());
        }

        [Test]
        public void GetWithInvalidCredentials()
        {
            // Should output status 200 ok but with error json
            string invalidId = "invalid";
            string invalidSecret = "invalid";
            string invalidOrgId = "invalid";

            var accessToken = new AccessToken(invalidId, invalidSecret, invalidOrgId);

            Assert.ThrowsAsync<Exception>(async () => await accessToken.Get());
        }
    }
}
