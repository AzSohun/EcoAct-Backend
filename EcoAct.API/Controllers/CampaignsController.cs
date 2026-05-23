using EcoAct.Application.DTOs.Campaigns;
using EcoAct.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EcoAct.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {

        private readonly ICampaignService _campaignService;

        public CampaignsController(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampaign([FromBody] CreateCampaignDto request)
        {
            var response = await _campaignService.CreateCampaignAsync(request);

            return CreatedAtAction(nameof(GetByIdCampaign), new {id = response.Id}, response);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCampaign()
        {
            var campaigns = await _campaignService.GetAllCampaignsAsync();

            return Ok(campaigns);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdCampaign(Guid id)
        {
            var campaign = await _campaignService.GetCampaignByIdAsync(id);

            if(campaign == null)
            {
                return NotFound(new { Message =$"Campaign with this {id} not found." });
            }

            return Ok(campaign);
        }
    }
}
