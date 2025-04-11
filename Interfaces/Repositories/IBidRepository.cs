using System.Threading.Tasks;
using System.Collections.Generic;
 using global::EntitiesTest.Entities;

namespace EntitiesTest.Application.Interfaces.Repositories{
        public interface IBidRepository
        {
        Task AddAsync(Bid bid);
        Task<List<Bid>> GetBidsByTenderIdAsync(Guid tenderId);
        Task<Bid> GetByIdAsync(Guid id);
        Task UpdateAsync(Bid bid);
        Task DeleteAsync(Guid id);
        Task <int> SaveChangesAsync();
        Task<List<Bid>> GetBidsForTenderAsync(Guid tenderId);

    }
}

