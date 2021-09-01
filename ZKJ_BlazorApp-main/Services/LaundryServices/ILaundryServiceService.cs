using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.LaundryServices
{
    interface ILaundryServiceService
    {
        Task<IEnumerable<LaundryService>> GetAllLaundry();
        Task<IEnumerable<LaundryService>> GetServiceByNumber(string number);
        Task<LaundryService> GetLaundryById(int id);
        Task<int> CreateLaundry(LaundryService laundry);
        Task<int> UpdateLaundry(LaundryService laundry);
        Task<bool> Delete(int id);
    }
}
