using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.LaundryServiceDetails
{
    interface ILaundryServiceDetailsService
    {
        Task<IEnumerable<LaundryServiceDetail>> GetAllLaundryDetails();
        Task<IEnumerable<LaundryServiceDetail>> GetLaundryServiceDetails(int laundryServiceId);
        Task<LaundryServiceDetail> GetLaundryDetailById(int id);
        Task<int> CreateLaundryDetails(LaundryServiceDetail laundryDetail);
        Task<int> UpdateLaundryDetails(LaundryServiceDetail laundryDetail);
        Task<int> Delete(int id);
    }
}
