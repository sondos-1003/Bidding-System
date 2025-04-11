using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Entities;
using System.Threading.Tasks;
using EntitiesTest.Infrastructure.Repositories;
using EntitiesTest.Application.Interfaces.Repositories;
using EntitiesTest.Application.Services.Interfaces;

namespace EntitiesTest.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IUserRepository Get_userRepository()
        {
            return _userRepository;
        }

        // Register a new user
        public async Task<User> RegisterUserAsync(User user)
        {
            if (user == null) return null;

            // Optionally, check if user exists before adding
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return null; // Or throw exception, or return existingUser
            }

            await _userRepository.AddAsync(user);
            return user;// After adding, return the user object
        }

        // Get a user by their ID
        public async Task<User> GetUserByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
        }
        // Other methods can be added here like updating or deleting users
    }
}
