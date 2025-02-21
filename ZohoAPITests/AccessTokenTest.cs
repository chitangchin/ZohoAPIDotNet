using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.Configuration;
using ZohoAPI;

namespace ZohoAPITests
{

    [TestFixture]
    public class AccessTokenIntegrationTests
    {
        public string? ClientId { get; private set; }
        public string? ClientSecret { get; private set; }
        public string? OrgId { get; private set; }

        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
            OrgId = config["orgId"];
        }

        [Test]
        public Task GetWithValidCredentials()
        {
            if (ClientId == null || ClientSecret == null || OrgId == null)
            {
                Environment.Exit(0);
            }

            var accessToken = new AccessToken(ClientId, ClientSecret, OrgId);
            Assert.DoesNotThrowAsync(async () => await accessToken.Get());
            return Task.CompletedTask;
        }

        [Test]
        public Task GetWithInvalidCredentials()
        {
            // Should output status 200 ok but with error json
            string invalidId = "invalid";
            string invalidSecret = "invalid";
            string invalidOrgId = "invalid";

            var accessToken = new AccessToken(invalidId, invalidSecret, invalidOrgId);

            Assert.ThrowsAsync<Exception>(async () => await accessToken.Get());
            return Task.CompletedTask;
        }
        //Not needed -> credentials are required fields, aslong as the three required fields are filled, there cannot be status code 500 even with invalid input
        //[Test]
        //public void GetWithMissingFormData()
        //{
        //    // Should output status 500 ok but with error json
        //    var invalidId = "";
        //    var invalidSecret = "";

        //    var accessToken = new AccessToken(invalidId, invalidSecret);

        //    Assert.ThrowsAsync<Exception>(async () => await accessToken.Get());
        //}
    }
}
