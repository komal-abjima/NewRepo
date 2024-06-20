using Five9_test.Models;
using Five9_test.Service.Helper;
using Five9_test.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Five9_test.Service
{
    public class Five9Service : IFive9Service
    {

        private readonly IConfiguration _configuration;

        public Five9Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      

        //getallcampaigns -supervisor
        public async Task<List<Campaigns>> getCampaigns()
        {
            Five9Apis _apis = new Five9Apis(_configuration);
            var loginResponse = await _apis.Login();
            var res = await _apis.getCampaigns(loginResponse);
            return res;
        }

        //start a campaign - supervisor
        public async Task StartCampaign()
        {
            Five9Apis _apis = new Five9Apis(_configuration);
            var loginResponse = await _apis.Login();
            var res = await _apis.StartCampaign(loginResponse);
            return res;
        }

        //get a list of inbound campaigns
        public async Task<List<Campaigns>> getInboundCampaigns()
        {
            Five9AgentAPIs _apis = new Five9AgentAPIs(_configuration);
            var loginResponse = await _apis.Login();
            var res = await _apis.getInboundCampaigns(loginResponse);
            return res;
        }

        //get a list of agents
        public async Task<List<SupervisorAgentInfo>> getAgents()
        {
            Five9Apis _apis = new Five9Apis(_configuration);
            var loginResponse = await _apis.Login();
            var res = await _apis.getAgents(loginResponse);
            return res;
        }
        //get a list of agents
        public async Task<List<AvailableCampaignsModel>> getavailableCampaigns()
        {
            Five9Apis _apis = new Five9Apis(_configuration);
            var loginResponse = await _apis.Login();
            var res = await _apis.getAvailableCampaigns(loginResponse);
            return res;
        }


        //gets the campaigns available to the agent
        public async Task<List<CampaignsConfigInfo>> getCampaignsAvailtoAgents()
        {
            Five9AgentAPIs _apis = new Five9AgentAPIs(_configuration);
            var loginResponse = await _apis.Login();
            var res = await _apis.getCampaignsAvailtoAgents(loginResponse);
            return res;
        }









    }
}
