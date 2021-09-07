using BlazorApp.Models;
using BlazorApp.Services.HttpServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.HotelLinenTypes
{
    public class HotelLinenTypeService : IHotelLinenTypeService
    {
        private readonly IHttpService httpService;

        public HotelLinenTypeService(IHttpService httpService)
        {
            this.httpService = httpService;
        }

        public async Task<HotelLinenType> Create(HotelLinenType linenType)
        {
            return await this.httpService.Post<HotelLinenType>("/HotelLinenTypes", linenType);

        }

        public async  Task<bool> Delete(int id)
        {
            await this.httpService.Delete($"/HotelLinenTypes/{id}");
            return true;
        }

        public async Task<IEnumerable<HotelLinenType>> GetAll()
        {
            return await this.httpService.Get<IEnumerable<HotelLinenType>>("/HotelLinenTypes");
        }

        public async Task<HotelLinenType> GetById(int id)
        {
            return await this.httpService.Get<HotelLinenType>($"/HotelLinenTypes/{id}");
        }

        public async Task<HotelLinenType> Update(HotelLinenType linenType)
        {
            return await this.httpService.Put<HotelLinenType>($"/HotelLinenTypes/{linenType.Id}", linenType);
        }
    }
}
