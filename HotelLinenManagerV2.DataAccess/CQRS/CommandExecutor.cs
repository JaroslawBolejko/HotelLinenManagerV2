using HotelLinenManagerV2.DataAccess.CQRS.Commands;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS
{

    public class CommandExecutor : ICommandExecutor
        {
            private readonly WarehauseStorageHotelLinenContext context;

            public CommandExecutor(WarehauseStorageHotelLinenContext context)
            {
                this.context = context;
            }

            public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
            {
                return command.Execute(this.context);
            }
        }
    
}
