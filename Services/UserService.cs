using DIIS.PersonApp.IServices;
using DIIS.PersonApp.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DIIS.PersonApp.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CurrentUser> GetCurrentUserAsync()
        {
            return await _httpClient.GetFromJsonAsync<CurrentUser>("data/current_user.json");
        }

    }
}
