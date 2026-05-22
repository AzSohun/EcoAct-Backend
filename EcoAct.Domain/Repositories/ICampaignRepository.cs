using EcoAct.Domain.Entities;


namespace EcoAct.Domain.Repositories
{
    public interface ICampaignRepository
    {
        Task<IEnumerable<Campaign>> GetAllAsync();
        Task<Campaign?> GetByIdAsync(Guid id);
        Task AddAsync(Campaign campaign);
        Task UpdateAsync(Campaign campaign);
        Task DeleteAsync(Guid id);
    }
}
