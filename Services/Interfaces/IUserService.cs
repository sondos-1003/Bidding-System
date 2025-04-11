using EntitiesTest.Entities;

namespace EntitiesTest.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(User user); // Changed to return User
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task AddAsync(User user);
    }

}
