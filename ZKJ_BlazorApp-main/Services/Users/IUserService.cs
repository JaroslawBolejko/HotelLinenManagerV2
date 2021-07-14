namespace BlazorApp.Services.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BlazorApp.Models;

    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetMe();
    }
}