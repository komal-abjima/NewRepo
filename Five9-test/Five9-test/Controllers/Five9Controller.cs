using Azure.Core;
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

        [HttpGet]
        [Route("getAvaialableCampaigns")]
        public async Task<ResponseWrapper<List<AvailableCampaigns>>> getavailableCampaigns()
        {
            var response = new ResponseWrapper<List<AvailableCampaigns>>();
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

