using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Commands
{
    public abstract class CommandBase<TParameter,TResult>
    {
        public TParameter Parameter { get; set; }
        public abstract Task<TResult> Execute(WarehauseStorageHotelLinenContext context);
    }
}
