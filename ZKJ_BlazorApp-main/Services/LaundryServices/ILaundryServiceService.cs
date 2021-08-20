using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.LaundryServices
{
    interface ILaundryServiceService
    {
        Task<IEnumerable<LaundryService>> GetAllLaundry();
        Task<LaundryService> GetLaundryById(int id);
        Task<int> CreateLaundry(LaundryService laundry);
        Task<int> UpdateLaundry(LaundryService laundry);
        Task<int> Delete(int id);
    }
}
