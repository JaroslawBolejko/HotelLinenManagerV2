namespace BlazorApp.Services.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetMe();
        Task<User> GetUserById(int id);
        Task<int> CreateUser(User user);
        Task<int> UpdateUserById(User user);
        Task<bool> Delete(int id);

    }
}