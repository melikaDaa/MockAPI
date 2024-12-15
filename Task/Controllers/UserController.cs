using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Task.Data;
using Task.Model;

namespace Task.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private static readonly HttpClient client = new HttpClient();

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("fetch")]
        public async Task<IActionResult> fetchAndAddUser() 
        {
            var items = await FetchDataFromApi("https://reqres.in/api/users");
            foreach (var item in items)
            {
                if(!await _context.Users.AnyAsync(i=>i.id== item.id))
                {
                    _context.Users.Add(item);
                }
            }
            await _context.SaveChangesAsync();
            return Ok(items);

        }

        private async Task<List<User>> FetchDataFromApi(string url)
        {
            var response = await client.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<User>>(response);
        }
    }
}
