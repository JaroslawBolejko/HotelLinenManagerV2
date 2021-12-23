using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Users
{
    public class UserService : IUserService
    {
        private IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<int> CreateUser(User user)
        {
           var result = await _httpService.Post<User>("/Users", user);
           return result.Id;
        }

        public async Task<bool> Delete(int id)
        {
            await _httpService.Delete($"/Users/{id}");
            return true;

        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _httpService.Get<IEnumerable<User>>("/Users");
        }

        public async Task<IEnumerable<User>> GetAll(string username)
        {
            return await _httpService.Get<IEnumerable<User>>($"/Users?Username={username}");

        }

        public async Task<User> GetMe()
        {
            return await _httpService.Get<User>("/Users/me");
        }

        public async Task<User> GetUserById(int id)
        {
            return await _httpService.Get<User>($"/Users/{id}");
        }

        public async Task<int> UpdateUserById(User user)
        {
            await _httpService.Put<User>($"/Users/{user.Id}", user);
            return user.Id;
        }
    }
}