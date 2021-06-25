using FluentValidation;
using HotelLinenManagerV2.ApplicationServices.API.Domain.Requests.Users;
using static HotelLinenManagerV2.DataAccess.Entities.User;

namespace HotelLinenManagerV2.ApplicationServices.API.Domain.Validiators.UserValidation
{
    public class UpdateUserVlidator : AbstractValidator<UpdateUserByIdRequest>
    {
        public UpdateUserVlidator()
        {
            this.RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.FirstName).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!")
                .MinimumLength(2).MaximumLength(100);
            this.RuleFor(x => x.LastName).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!")
                .MinimumLength(2).MaximumLength(100);
            this.RuleFor(x => x.Position).IsInEnum().WithMessage("Niewłaściwy typ {PropertyName}. Wybierz z listy dostępnych!");
            this.RuleFor(x => x.CompanyId).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!");
            this.RuleFor(x => x.Permission).IsInEnum().WithMessage("Niewłaściwy typ {PropertyName}. Wybierz z listy dostępnych!");
            this.RuleFor(x => x.Password).NotEmpty().MaximumLength(50);
            this.RuleFor(x => x.Username).NotEmpty().MaximumLength(50);
            this.RuleFor(x => x.Email).NotEmpty().WithMessage("Pole {PopertyName} nie może być puste!")
                .EmailAddress().WithMessage("to nie jest prawidłowy format e-mail!");
        }
    }
}
