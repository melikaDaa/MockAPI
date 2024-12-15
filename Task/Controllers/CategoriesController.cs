using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks1.Models;

namespace Tasks1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        private readonly AppDbContext _context;

        public CategoriesController(CategoryService categoryService, AppDbContext context)
        {
            _categoryService = categoryService;
            _context = context;
        }

        [HttpPost("fetch-and-store")]
        public async Task<IActionResult> FetchAndStoreCategories()
        {
            await _categoryService.FetchAndStoreCategoriesAsync();
            return Ok("Categories fetched and stored successfully.");
        }
        [HttpGet("fetch")]
        public async Task<IActionResult> FetchCategories() 
        { var categories = await _categoryService.FetchCategoriesAsync();
            return Ok(categories);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        { 
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState); 
            }
            var createdCategory = await _categoryService.AddCategoryAsync(category); 
            return Ok(createdCategory);
        }

    }

}
