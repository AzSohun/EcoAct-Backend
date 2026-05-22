using EcoAct.Domain.Entities;
using EcoAct.Domain.Repositories;
using EcoAct.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace EcoAct.Infrastructure.Repositories
{
    public class CampaignRepository: ICampaignRepository
    {

        private readonly ApplicationDbContext _context;

        public CampaignRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Campaign>> GetAllAsync()
        {
            var campaigns = await _context.Campaigns.ToListAsync();

            return campaigns;
        }

    }
}
