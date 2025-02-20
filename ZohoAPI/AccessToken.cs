using System.Text.Json;

namespace ZohoAPI
{
    public class AccessToken(string _clientId, string _clientSecret, string _orgId)
    {
        //Latest token URL
        private const string TokenUrl = "https://accounts.zoho.com/oauth/v2/token";
        private static readonly HttpClient client = new();

        //Getting access token from zoho
        public async Task<string> Get()
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
                using var response = await client.PostAsync(TokenUrl, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                /* Zoho outputs status code 200 if all fields are populated but invalid
                    JSON response:
                    {
                        "error": "invalid_code"
                    }  
                */
                using var jsonDoc = JsonDocument.Parse(responseBody);
                if (jsonDoc.RootElement.TryGetProperty("error", out var errorElement))
                {
                    string? errorMessage = errorElement!.GetString();
                    throw new Exception($"API error: {errorMessage}");
                }

                return responseBody;
            }
            catch (HttpRequestException error)
            {
                throw new InvalidDataException($"Message: {error.Message}");
            }
        }
    }
}
