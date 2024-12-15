using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Data;
using Task1.Model;

namespace Task1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly ApplicationDbContext _context;

        public UsersController(UserService userService, ApplicationDbContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpGet("fetch-and-store")]
        public async Task<IActionResult> FetchAndStoreUsers()
        {
            var users = await _userService.FetchUsersAsync();

            foreach (var user in users)
            {
                var existingUser = await _context.Users.FindAsync(user.Id);
                if (existingUser == null)
                {
                    // Add new user if it doesn't exist
                    _context.Users.Add(user);
                }
                else
                {
                    // Update existing user if it exists
                    _context.Entry(existingUser).CurrentValues.SetValues(user);
                }
            }

            await _context.SaveChangesAsync();
            return Ok(users);
        }

    }



}

