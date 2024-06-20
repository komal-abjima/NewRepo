using Five9_test.Models;
using Microsoft.AspNetCore.Mvc;

namespace Five9_test.Service.Interface
{
    public interface IFive9Service
    {
        
        Task<List<Campaigns>> getCampaigns();

        Task<List<SupervisorAgentInfo>> getAgents();
        Task<List<Campaigns>> getInboundCampaigns();
        Task<List<AvailableCampaignsModel>> getavailableCampaigns();
        Task<List<CampaignsConfigInfo>> getCampaignsAvailtoAgents();
    }
}
