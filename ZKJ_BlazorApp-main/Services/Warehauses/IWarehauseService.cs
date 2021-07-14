using BlazorApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp.Services.Warehauses
{
    interface IWarehauseService
    {
        Task<IEnumerable<Warehause>> GetAll();
    }
}
