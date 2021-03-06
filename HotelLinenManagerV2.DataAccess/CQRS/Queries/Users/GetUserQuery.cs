using HotelLinenManagerV2.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelLinenManagerV2.DataAccess.CQRS.Queries.Users
{
    public class GetUserQuery : QueryBase<User>
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CompanyId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public override async Task<User> Execute(WarehauseStorageHotelLinenContext context)
        {
           if(!string.IsNullOrEmpty(this.FirstName)
                && !string.IsNullOrEmpty(this.LastName)
                && !string.IsNullOrEmpty(this.Email)
                && this.CompanyId !=null)
            {

                return await context.Users
                    .Include(x=>x.Company)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.FirstName == this.FirstName
                 && x.LastName == this.LastName 
                 && x.Email == this.Email 
                 && x.CompanyId == this.CompanyId);
                      
            }
            if (!string.IsNullOrEmpty(this.Username))
            {
                return await context.Users
                                    .Include(x => x.Company)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(x => x.Username == this.Username);
            }

           if(this.Id!=null)
            {
                return await context.Users.FirstOrDefaultAsync(x => x.Id == this.Id);
            }
           
            if (!string.IsNullOrEmpty(this.Username))
            {
                
                return await context.Users
                    .Include(x=>x.Company)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Username == this.Username);

            }
            return  null;

        }
    }
}
