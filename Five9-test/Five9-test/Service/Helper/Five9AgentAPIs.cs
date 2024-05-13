using Five9.Models;
using Five9_test.Models;
using System.Text.Json;

namespace Five9_test.Service.Helper
{
    public class Five9AgentAPIs
    {
        private readonly IConfiguration _configuration;

        public Five9AgentAPIs(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Five9LoginApiResponseItem> Login()
        {

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://app.five9.com/appsvcs/rs/svc/auth/login/");
                var user = _configuration.GetValue<string>("Username1");
                var pass = _configuration.GetValue<string>("Password1");
                var login = new Five9LoginRequest()
                {
                    passwordCredentials = new Five9LoginRequest.PasswordCredentials { username = _configuration.GetValue<string>("Username1"), password = _configuration.GetValue<string>("Password1") },
                    policy = "ForceIn"
                };
                var content = new StringContent(JsonSerializer.Serialize(login).ToString(), null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var responseItem = JsonSerializer.Deserialize<Five9LoginApiResponseItem>(result);
                var session = await StartSession(responseItem);
                var cs = await CheckSession(responseItem);
                return responseItem;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<string> StartSession(Five9LoginApiResponseItem five9LoginApiResponseItem)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Put, $"https://app-atl.five9.com/appsvcs/rs/svc/agents/{five9LoginApiResponseItem.agentId}/session_start?force=false");
                request.Headers.Add("Cookie", $"Authorization=Bearer-{five9LoginApiResponseItem.tokenId};farmId={five9LoginApiResponseItem.context.farmId}");
                var content = new StringContent("{\r\n \"stationId\": \"\",\r\n \"stationType\": \"EMPTY\"\r\n}", null, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();


            }
            catch (Exception ex)
            {
                //Logger.Error($"StartSession exception {ex}");
                return null;

            }
        }

        public async Task<string> CheckSession(Five9LoginApiResponseItem responseItem)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://app-atl.five9.com/appsvcs/rs/svc/supervisors/{responseItem.agentId}/login_state");
                request.Headers.Add("Cookie", $"Authorization=Bearer-{responseItem.tokenId}; farmId={responseItem.context.farmId}");
                var response = await client.SendAsync(request);
                var state = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return state;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }


        //get a list of inbound campaigns

        public async Task<List<Campaigns>> getInboundCampaigns(Five9LoginApiResponseItem responseItem)
        {

            try
            {
                var client = new HttpClient();


                var request = new HttpRequestMessage(HttpMethod.Get, $"https://app-atl.five9.com/appsvcs/rs/svc/agents/{responseItem.agentId}/campaigns");

                request.Headers.Add("Cookie", $"Authorization=Bearer-{responseItem.tokenId};farmId={responseItem.context.farmId}");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStreamAsync();
                var campaigns = await JsonSerializer.DeserializeAsync<List<Campaigns>>(result);
                return campaigns;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to retrieve outbound campaigns. Error: {ex.Message}");
            }

        }

    }
}
