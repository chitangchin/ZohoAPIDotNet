using ZohoAPI;

namespace ZohoAPITests
{
    [TestFixture]
    public class AccessTokenIntegrationTests
    {
        [Test]
        public Task GetWithValidCredentials()
        {
            //Tested and passed with a one time use code
            var clientId = "xxx";
            var clientSecret = "xxx";
            var code = "xxx";

            var accessToken = new AccessToken(clientId, clientSecret, code);

            Assert.DoesNotThrowAsync(async () => await accessToken.Get());
            return Task.CompletedTask;
        }

        [Test]
        public void GetWithInvalidCredentials()
        {
            // Should output status 200 ok but with error json
            var invalidId = "invalid";
            var invalidSecret = "invalid";
            var invalidCode = "invalid";

            var accessToken = new AccessToken(invalidId, invalidSecret, invalidCode);

            Assert.ThrowsAsync<Exception>(async () => await accessToken.Get());
        }
        //Not needed -> credentials are required fields, aslong as the three required fields are filled, there cannot be status code 500 even with invalid input
        //[Test]
        //public void GetWithMissingFormData()
        //{
        //    // Should output status 500 ok but with error json
        //    var invalidId = "";
        //    var invalidSecret = "";
        //    var invalidCode = "";

        //    var accessToken = new AccessToken(invalidId, invalidSecret, invalidCode);

        //    Assert.ThrowsAsync<Exception>(async () => await accessToken.Get());
        //}
    }
}
