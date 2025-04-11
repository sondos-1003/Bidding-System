using Microsoft.AspNetCore.Mvc;
using EntitiesTest.Application.Services;
using EntitiesTest.Entities;
using System.Threading.Tasks;
using EntitiesTest.Application.Services.Interfaces;
namespace EntitiesTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //private readonly UserService _userService;
        private readonly IUserService _userService;
        // Inject UserService into the controller
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/users/register
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            var registeredUser = await _userService.RegisterUserAsync(user);
            if (registeredUser == null)
            {
                return BadRequest("Registration failed.");
            }

            return CreatedAtAction(nameof(GetUserById), new { id = registeredUser.Id }, registeredUser);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        // Additional actions like updating or deleting users can be added here
    }
}
