using System.Text.Json;
using Task1.Model;

namespace Task1.Data
{
    public class UserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

   
            public async Task<List<User>> FetchUsersAsync()
            {
                var response = await _httpClient.GetAsync("https://reqres.in/api/users");
                response.EnsureSuccessStatusCode();

                var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponse>();

                // Set the Id to 0 for each user to let EF Core generate new IDs
                var users = apiResponse?.Data ?? new List<User>();
                users.ForEach(u => u.Id = 0);

                return users;
            }
        }

    

    public class ApiResponse
    {
        public List<User> Data { get; set; }
    }

}
