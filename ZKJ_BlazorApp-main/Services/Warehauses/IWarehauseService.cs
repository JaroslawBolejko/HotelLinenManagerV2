using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Warehauses
{
    interface IWarehauseService
    {
        Task<IEnumerable<Warehause>> GetAll();
        Task<IEnumerable<Warehause>> GetWarehausesByType(int type);
        Task<Warehause> GetWarehauseById(int id);
        Task<int> CreateWarehause(Warehause warehause);
        Task<int> Update(Warehause warehause);
        Task<bool> Delete(int id);

    }
}
