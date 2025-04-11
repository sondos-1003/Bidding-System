
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using global::EntitiesTest.Entities;
using EntitiesTest.Application.Services;

    namespace EntitiesTest.Application.Interfaces.Repositories
    {
        public interface IUserRepository
        {
            Task AddAsync(User user);
            Task<User> GetByIdAsync(int id);
            //Task<List<User>> GetAllAsync();
        Task<IEnumerable<User>> GetAllAsync();
        Task<int> SaveChangesAsync();

        Task UpdateAsync(User user);
            Task DeleteAsync(int id);
        Task<User> GetByEmailAsync(string email);
        //Task SaveChangesAsync();


    }
}


