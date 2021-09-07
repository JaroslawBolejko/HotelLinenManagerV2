using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.HotelLinenTypes
{
    interface IHotelLinenTypeService
    {
        Task<IEnumerable<HotelLinenType>> GetAll();
        Task<HotelLinenType> GetById(int id);
        Task<HotelLinenType> Create(HotelLinenType linenType);
        Task<HotelLinenType> Update(HotelLinenType linenType);
        Task<bool> Delete(int id);
             
    }
}

