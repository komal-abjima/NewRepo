using Five9.Models;
using Five9_test.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Five9_test.Service.Helper
{
    public class Five9Apis
    {
        private readonly IConfiguration _configuration;
        public Five9Apis(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Five9LoginApiResponseItem> Login()
        {

            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://app.five9.com/supsvcs/rs/svc/auth/login/");
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
                var request = new HttpRequestMessage(HttpMethod.Put, $"https://app-atl.five9.com/supsvcs/rs/svc/supervisors/{five9LoginApiResponseItem.userId}/session_start?force=true");
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
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://app-atl.five9.com/supsvcs/rs/svc/supervisors/{responseItem.userId}/login_state");
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


        //getallcampaigns
        public async Task<List<Campaigns>> getCampaigns(Five9LoginApiResponseItem responseItem)
        {

            try
            {
                var client = new HttpClient();


                var request = new HttpRequestMessage(HttpMethod.Get, $"https://app-atl.five9.com/supsvcs/rs/svc/orgs/{responseItem.orgId}/campaigns");
               
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

        //starts a campaign 
        public async Task StartCampaign(Five9LoginApiResponseItem responseItem, string campaignId)
        {
            try
            {
                var client = new HttpClient();
                if (!HasPermission(responseItem.permissions, Permission.CAN_START_CAMPAIGNS))
                {
                    throw new Exception("User does not have permission to start campaigns.");
                }

                var request = new HttpRequestMessage(HttpMethod.Put, $"https://app-atl.five9.com/supsvcs/rs/svc/orgs/{responseItem.orgId}/campaigns/{campaignId}/start");

                // Add authorization headers
                request.Headers.Add("Authorization", $"Bearer {responseItem.tokenId}");
                request.Headers.Add("farmId", responseItem.context.farmId);

                var response = await client.SendAsync(request);

                
                response.EnsureSuccessStatusCode();

                // If response is successful, no content is expected
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to start campaign. Status code: {response.StatusCode}");
                }

                // If response is empty, return
                return;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to start campaign. Error: {ex.Message}");
            }
        }

        private bool HasPermission(List<Permission> permissions, Permission requiredPermission)
        {
            return permissions.Contains(requiredPermission);
        }
 




    //get avaialable campaigns
    public async Task<List<AvailableCampaignsModel>> getAvailableCampaigns(Five9LoginApiResponseItem responseItem)
        {

            try
            {
                var client = new HttpClient();


                var request = new HttpRequestMessage(HttpMethod.Get, $"https://app-atl.five9.com/supsvcs/rs/svc/orgs/{responseItem.orgId}/available_campaigns");

                request.Headers.Add("Cookie", $"Authorization=Bearer-{responseItem.tokenId};farmId={responseItem.context.farmId}");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStreamAsync();
                var campaigns = await JsonSerializer.DeserializeAsync<List<AvailableCampaignsModel>>(result);
                return campaigns;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to retrieve outbound campaigns. Error: {ex.Message}");
            }

        }


        //getallcampaigns
        public async Task<List<SupervisorAgentInfo>> getAgents(Five9LoginApiResponseItem responseItem)
        {

            try
            {
                var client = new HttpClient();


                var request = new HttpRequestMessage(HttpMethod.Get, $"https://app-atl.five9.com/supsvcs/rs/svc/supervisors/{responseItem.userId}/agents");

                request.Headers.Add("Cookie", $"Authorization=Bearer-{responseItem.tokenId};farmId={responseItem.context.farmId}");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStreamAsync();
                var campaigns = await JsonSerializer.DeserializeAsync<List<SupervisorAgentInfo>>(result);
                return campaigns;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Failed to retrieve outbound campaigns. Error: {ex.Message}");
            }

        }











    }
}

