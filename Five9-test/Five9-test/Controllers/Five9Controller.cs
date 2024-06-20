using Azure.Core;
using Five9.Models;
using Five9_test.Models;
using Five9_test.Service;
using Five9_test.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Five9_test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Five9Controller : ControllerBase
    {
        private readonly IFive9Service _service;
        public Five9Controller(IFive9Service service)
        {
            _service = service;
        }

        //gets availabale campaigns
        [HttpGet]
        [Route("getAvaialableCampaigns")]
        public async Task<ResponseWrapper<List<AvailableCampaignsModel>>> getavailableCampaigns()
        {
            var response = new ResponseWrapper<List<AvailableCampaignsModel>>();
            try
            {
                response.Set(await _service.getavailableCampaigns());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

        //gets all the campaigns in the domain
        [HttpGet]
        [Route("getCampaigns")]
        public async Task<ResponseWrapper<List<Campaigns>>> getCampaigns()
        {
            var response = new ResponseWrapper<List<Campaigns>>();
            try
            {
                response.Set(await _service.getCampaigns());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }


        ////gets information about a campaign ID in the domain
        //[HttpGet("{campaignId}")]
        //[Route("getCampaignInfo")]
        //public async Task<ResponseWrapper<Campaigns>> getCampaignInfo(string campaignId)
        //{
        //    var response = new ResponseWrapper<Campaigns>();
        //    try
        //    {
        //        response.Set(await _service.getCampaignInfo(campaignId));
        //    }
        //    catch (Exception ex)
        //    {
        //        response.Set(ex);
        //    }
        //    return response;
        //}

        //gets a list of Inbound Campaigns
        [HttpGet]
        [Route("getinboundCampaigns")]
        public async Task<ResponseWrapper<List<Campaigns>>> getInboundCampaigns()
        {
            var response = new ResponseWrapper<List<Campaigns>>();
            try
            {
                response.Set(await _service.getInboundCampaigns());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }

       

        //gets the campaigns available to the agent
        [HttpGet]
        [Route("getCampaignsAvailtoAgents")]
        public async Task<ResponseWrapper<List<CampaignsConfigInfo>>> getCampaignsAvailtoAgents()
        {
            var response = new ResponseWrapper<List<CampaignsConfigInfo>>();
            try
            {
                response.Set(await _service.getCampaignsAvailtoAgents());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }



        //gets all the agents
        [HttpGet]
        [Route("getAgents")]
        public async Task<ResponseWrapper<List<SupervisorAgentInfo>>> getAgents()
        {
            var response = new ResponseWrapper<List<SupervisorAgentInfo>>();
            try
            {
                response.Set(await _service.getAgents());
            }
            catch (Exception ex)
            {
                response.Set(ex);
            }
            return response;
        }







    }

}

