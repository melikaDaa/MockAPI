using System.Net.Http.Json;
using Tasks1.Models;

namespace Tasks1
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly AppDbContext _context;

        public CategoryService(HttpClient httpClient, AppDbContext context)
        {
            _httpClient = httpClient;
            _context = context;
        }

        public async Task FetchAndStoreCategoriesAsync()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<Category>>("https://672906f86d5fa4901b6be0d9.mockapi.io/Category");
            if (categories != null)
            {
                foreach (var category in categories)
                {
                    _context.Categories.Add
                        (new Category { Title = category.Title, Desc = category.Desc }
                        );
                }
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Category>> FetchCategoriesAsync()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<Category>>("https://672906f86d5fa4901b6be0d9.mockapi.io/Category");
            return categories ?? new List<Category>();
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("https://672906f86d5fa4901b6be0d9.mockapi.io/Category", category);
            if (response.IsSuccessStatusCode)
            {
                var createdCategory = await response.Content.ReadFromJsonAsync<Category>();
                return createdCategory;
            }
            else
            {
                throw new Exception("Error adding category to external API.");
            }
        }
    }

}
