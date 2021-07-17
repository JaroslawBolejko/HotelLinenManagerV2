using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.HotelLinens
{
    public interface IHotelLinenService
    {
        Task<IEnumerable<HotelLinen>> GetAll();
        Task<IEnumerable<HotelLinen>> GetWarehauseLinen(int warehauseId);
        Task<HotelLinen> Create(HotelLinen hotelLinen);
        Task<int> Delete(int Id);
        Task<HotelLinen> Update(HotelLinen hotelLinen);
        Task<HotelLinen> GetById(int Id);
    }
}
