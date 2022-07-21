using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Commands.EditCustomer
{
    public class EditCustomerCommandValidator : AbstractValidator<EditCustomerCommand>
    {
        public EditCustomerCommandValidator()
        {
            RuleFor(validator => validator.Id)
                .NotEqual(0).WithMessage("El Id debe ser mayor a cero");

            RuleFor(validator => validator.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Nombre no debe ser nulo")
                .NotEmpty().WithMessage("El campo nombre no debe ser nulo")
                .MinimumLength(3).WithMessage("El campo debe ser mayor o igual a {MinLength} caracteres. Ha ingresado {TotalLength} caracteres(es)")
                .MaximumLength(50).WithMessage("El campo nombre debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(validator => validator.FirstLastName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Apellido Paterno no debe ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Paterno no debe ser nulo")
                .MinimumLength(3).WithMessage("El Apellido Paterno debe ser mayor o igual a {MinLength} caracteres. Ha ingresado {TotalLength} caracteres(es)")
                .MaximumLength(50).WithMessage("El campo Apellido Paterno debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(validator => validator.SecondLastName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El Apellido Materno es requerido")
                .NotEmpty().WithMessage("El Apellido Materno no debe estár vacio")
                .MaximumLength(50).WithMessage("El Apellido Materno excede el límite de caracteres");

            RuleFor(validator => validator.RFC)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo RFC no debe ser nulo")
                .NotEmpty().WithMessage("El campo RFC no debe ser nulo")
                .MaximumLength(20).WithMessage("El campo RFC debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(validator => validator.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Correo no debe ser nulo")
                .NotEmpty().WithMessage("El campo Correo no debe ser nulo")
                .EmailAddress().WithMessage("El campo correo es invalido. El correo de ser como: example@.example.com")
                .MaximumLength(50).WithMessage("El campo correo debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(validator => validator.Address)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Domicilio no debe ser nulo")
                .NotEmpty().WithMessage("El campo Domicilio no debe ser vacio")
                .MaximumLength(150).WithMessage("El campo Domicilio debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");
        }
    }
}
