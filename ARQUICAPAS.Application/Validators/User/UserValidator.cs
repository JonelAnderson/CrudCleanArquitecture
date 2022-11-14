using ARQUICAPAS.Application.Dtos.User.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARQUICAPAS.Application.Validators.User
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).Length(4, 30).WithMessage("El {PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres.")
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre es requerido.");

            RuleFor(x => x.Password).Length(8, 16).WithMessage("El {PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres.")
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre es requerido.");

            RuleFor(x => x.Email).MaximumLength(100).WithMessage("El Email no debe contener más de 100 caracteres")
                .NotNull().WithMessage("El campo email no puede ser nulo.")
                .NotEmpty().WithMessage("El email es requerido");
        }
    }
}
