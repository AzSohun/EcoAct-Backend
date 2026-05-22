using EcoAct.Application.DTOs.Campaigns;
using EcoAct.Application.Services.Interfaces;
using EcoAct.Domain.Entities;
using EcoAct.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoAct.Application.Services
{
    internal class CapmpaignService: ICampaignService
    {

        private readonly ICampaignRepositories _repository;

        public CapmpaignService(ICampaignRepositories repository)
        {
            _repository = repository;
        }


        public async Task<CampaignResponseDto> CreateCampaignAsync(CreateCampaignDto dto)
        {

            var campaign = new Campaign
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Despcription = dto.Description,
                TargetTrees = dto.TargetTrees,
                PlantedTrees = 0,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(campaign);

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

    }
}
