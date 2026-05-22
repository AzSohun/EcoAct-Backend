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


        public async Task<Campaign?> GetByIdAsync(Guid id)
        {
            var campaign = await _context.Campaigns.FindAsync(id);

            if(campaign == null)
            {
                return null;
            }

            return campaign;
        }


        public async Task AddAsync(Campaign campaign)
        {
            await _context.Campaigns.AddAsync(campaign);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Campaign campaign)
        {
            _context.Campaigns.Update(campaign);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(Guid id)
        {
            var existingCampaign = await GetByIdAsync(id);

            if(existingCampaign != null)
            {
                _context.Campaigns.Remove(existingCampaign);
                await _context.SaveChangesAsync();
            }
        }
    }
}
