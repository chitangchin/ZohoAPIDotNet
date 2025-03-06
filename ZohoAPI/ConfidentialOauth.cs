using System.Text.Json;

namespace ZohoAPI
{
    public class ConfidentialOauth(string _clientId, string _clientSecret, string _orgId)
    {
        //Latest token URL
        private const string TokenUrl = "https://accounts.zoho.com/oauth/v2/token";
        private static readonly HttpClient client = new();

        //Getting access token from zoho
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                Dictionary<string, string> FormData = new()
                {
                    { "client_id", _clientId },
                    { "client_secret", _clientSecret },
                    { "grant_type", "client_credentials" },
                    { "scope", "ZohoCRM.settings.READ" },
                    { "soid", $"ZohoCRM.{_orgId}" },
                };

                var content = new FormUrlEncodedContent(FormData);
                var response = await client.PostAsync(TokenUrl, content);

                /* Zoho outputs status code 200 if all fields are populated but invalid
                    JSON response:
                    {
                        "error": "invalid_code"
                    }  
                */
                Console.WriteLine(response);
                return response;
            }
            catch (HttpRequestException error)
            {
                throw new InvalidDataException($"Message: {error.Message}");
            }
        }
    }
}
