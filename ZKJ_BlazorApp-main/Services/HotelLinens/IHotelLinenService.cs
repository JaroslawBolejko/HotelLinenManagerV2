using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.HotelLinens
{
    public interface IHotelLinenService
    {
        Task<IEnumerable<HotelLinen>> GetAll();
        Task<HotelLinen> Create(HotelLinen hotelLinen);
        Task<bool> Delete(int id);
        Task<HotelLinen> Update(HotelLinen hotelLinen);
        Task<HotelLinen> GetById(int id);
    }
}
