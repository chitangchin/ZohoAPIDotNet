using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.Extensions.Configuration;
using ZohoAPI;

namespace ZohoAPITests
{

    [TestFixture]
    public class AccessTokenIntegrationTests
    {
        [Test]
        public Task GetWithValidCredentials()
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<Program>()
                .Build();

            string? clientId = config["clientId"];
            string? clientSecret = config["clientSecret"];
            string? orgId = config["ordId"];

            if (orgId == null || clientSecret == null || clientId == null)
            {
                Console.WriteLine("Please configure your client ID, client secrete, or org ID");
                Environment.Exit(0);
            }

            //Tested and passed with a one time use code
            //string clientId = "1000.8Q4BC725A1DE7JLYT6ZNWTTF6701BY";
            //string clientSecret = "b888aed555351bd90ddda0efd7b4f657e89eeddcda";
            //string orgId = "41749829";

            var accessToken = new AccessToken(clientId, clientSecret, orgId);

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
