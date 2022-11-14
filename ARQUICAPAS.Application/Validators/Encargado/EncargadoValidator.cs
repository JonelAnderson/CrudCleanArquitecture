using ARQUICAPAS.Application.Dtos.Encargado.Request;
using FluentValidation;

namespace ARQUICAPAS.Application.Validators.Encargado
{
    public class EncargadoValidator : AbstractValidator<EncargadoRequestDto>
    {
        public EncargadoValidator()
        {
            RuleFor(x => x.Name).Length(4, 50).WithMessage("El {PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres.")
                .NotNull().WithMessage("El campo Nombre no puede ser nulo.")
                .NotEmpty().WithMessage("El campo Nombre es requerido.");


            RuleFor(x => x.LastName).Length(4, 50).WithMessage("El {PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres.")
                .NotNull().WithMessage("El campo Apellido no puede ser nulo.")
                .NotEmpty().WithMessage("El Apellido es requerido");


            RuleFor(x => x.Email).MaximumLength(100).WithMessage("El Email no debe contener más de 100 caracteres")
                .NotNull().WithMessage("El campo email no puede ser nulo.")
                .NotEmpty().WithMessage("El email es requerido");


            RuleFor(x => x.Phone).Length(9, 11).WithMessage("El {PropertyName} tiene {TotalLength} caracteres. Debe tener una longitud entre {MinLength} y {MaxLength} caracteres.")
                .NotNull().WithMessage("El campo teléfono no puede ser nulo.")
                .NotEmpty().WithMessage("El teléfono es requerido");
        }
    }
}
