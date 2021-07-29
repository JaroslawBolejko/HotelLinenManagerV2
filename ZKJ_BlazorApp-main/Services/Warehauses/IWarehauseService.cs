using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Warehauses
{
    interface IWarehauseService
    {
        Task<IEnumerable<Warehause>> GetAll();
        Task<Warehause> GetWarehauseById(int id);
        Task<int> Update(Warehause warehause);
    }
}
