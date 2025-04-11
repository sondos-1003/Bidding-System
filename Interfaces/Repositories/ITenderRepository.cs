
    
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using global::EntitiesTest.Entities;

namespace EntitiesTest.Application.Interfaces.Repositories
{
    public interface ITenderRepository
    {
        Task AddAsync(Tender tender);
        Task<Tender> GetByIdAsync(int id);
        //Task<List<Tender>> GetAllAsync();
        Task<IEnumerable<Tender>> GetAllAsync();

        Task UpdateAsync(Tender tender);
        Task DeleteAsync(int id);
       // Task SaveChangesAsync();
        Task<int> SaveChangesAsync();

    }
}

