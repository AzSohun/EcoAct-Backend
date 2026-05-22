using EcoAct.Application.DTOs.Campaigns;
using EcoAct.Application.Services.Interfaces;
using EcoAct.Domain.Entities;
using EcoAct.Domain.Repositories;


namespace EcoAct.Application.Services
{
    public class CampaignService: ICampaignService
    {

        private readonly ICampaignRepository _campaignRepository;

        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }


        public async Task<CampaignResponseDto> CreateCampaignAsync(CreateCampaignDto dto)
        {

            var campaign = new Campaign
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                TargetTrees = dto.TargetTrees,
                PlantedTrees = 0,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _campaignRepository.AddAsync(campaign);

            return new CampaignResponseDto
            {
                Id = campaign.Id,
                Title = campaign.Title,
                Description = campaign.Title,
                TargetTrees = campaign.TargetTrees,
                PlantedTrees = campaign.PlantedTrees,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                IsActive = campaign.IsActive
            };

        }


        public async Task<IEnumerable<CampaignResponseDto>> GetAllCampaignsAsync()
        {
            var campaigns = await _campaignRepository.GetAllAsync();

            var campaignList = campaigns.Select(campaign => new CampaignResponseDto
            {
                Id = campaign.Id,
                Title = campaign.Title,
                Description = campaign.Description,
                TargetTrees = campaign.TargetTrees,
                PlantedTrees = campaign.PlantedTrees,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                IsActive = campaign.IsActive
            }).ToList();

            return campaignList;
        }


        public async Task<CampaignResponseDto?> GetCampaignByIdAsync(Guid id)
        {

            var campaign = await _campaignRepository.GetByIdAsync(id);

            if(campaign == null)
            {
                return null;
            }

            var campaignDto = new CampaignResponseDto
            {
                Id = campaign.Id,
                Title = campaign.Title,
                Description = campaign.Description,
                TargetTrees = campaign.TargetTrees,
                PlantedTrees = campaign.PlantedTrees,
                StartDate = campaign.StartDate,
                EndDate = campaign.EndDate,
                IsActive = campaign.IsActive
            };

            return campaignDto;

        }
    }
}
