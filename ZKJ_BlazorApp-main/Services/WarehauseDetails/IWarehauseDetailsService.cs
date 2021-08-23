using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.WarehauseDetails
{
    public interface IWarehauseDetailsService
    {
        Task<IEnumerable<WarehauseDetail>> GetAllDetails();
        Task<WarehauseDetail> GetWarehauseDetailById(int id);
        Task<IEnumerable<WarehauseDetail>> GetWarehauseLinen(int warehauseId);
        Task<IEnumerable<WarehauseDetail>> GetDetailsWithQuery(int warehauseId, int hotelLinenId);
        Task<int> CreateDetails(WarehauseDetail warehauseDetail);
        Task<int> UpdateDetails(WarehauseDetail warehausedetail);
        Task<bool> Delete(int id);
    }
}
