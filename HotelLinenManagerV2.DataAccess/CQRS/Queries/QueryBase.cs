using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries
{
    public abstract class QueryBase<TResult>
    {    
        public abstract Task<TResult> Execute(WarehauseStorageHotelLinenContext context);

    }
}
