using EcoAct.Application.DTOs.Campaigns;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcoAct.Application.Services.Interfaces
{
    public interface ICampaignService
    {
        Task<IEnumerable<CampaignResponseDto>> GetAllCampaignsAsync();
        Task<CampaignResponseDto?> GetCampaignByIdAsync(Guid id);
        Task<CampaignResponseDto> CreateCampaignAsync(CreateCampaignDto dto);
    }
}
