using AutoMapper;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Models;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using System.Collections.Generic;
using System.Linq;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<HotelLinenManagerV2.DataAccess.Entities.User, User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.Permission, y => y.MapFrom(z => z.Permission))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
                .ForMember(x => x.PhotoPath, y => y.MapFrom(z => z.PhotoPath))
                //.ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                //.ForMember(x => x.Salt, y => y.MapFrom(z => z.Salt))
                .ForMember(x => x.Company, y => y.MapFrom(z => z.Company));


            this.CreateMap<CreateUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.Permission, y => y.MapFrom(z => z.Permission))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.PhotoPath, y => y.MapFrom(z => z.PhotoPath))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));

            this.CreateMap<UpdateUserByIdRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.LastName))
                .ForMember(x => x.CompanyId, y => y.MapFrom(z => z.CompanyId))
                .ForMember(x => x.Permission, y => y.MapFrom(z => z.Permission))
                .ForMember(x => x.Password, y => y.MapFrom(z => z.Password))
                .ForMember(x => x.Username, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Email, y => y.MapFrom(z => z.Email));

            this.CreateMap<DeleteUserByIdRequest, DataAccess.Entities.User>()
                    .ForMember(x => x.Id, y => y.MapFrom(z => z.Id));
        }
    }
}
