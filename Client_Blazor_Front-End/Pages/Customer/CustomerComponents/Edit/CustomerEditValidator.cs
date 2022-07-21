using DTOs;
using FluentValidation;

namespace Client_Blazor_Front_End.Pages.Customer.CustomerComponents.Edit
{
    public class CustomerEditValidator: AbstractValidator<CustomerDTO>
    {
        public CustomerEditValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Nombre no debe ser nulo")
                .NotEmpty().WithMessage("El campo nombre no debe ser vacio")
                .MinimumLength(3).WithMessage("El campo debe ser mayor o igual a {MinLength} caracteres. Ha ingresado {TotalLength} caracteres(es)")
                .MaximumLength(50).WithMessage("El campo nombre debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(x => x.FirstLastName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Apellido Paterno no debe ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Paterno no debe ser vacio")
                .MinimumLength(3).WithMessage("El campo Apellido Paterno debe ser mayor o igual a {MinLength} caracteres. Ha ingresado {TotalLength} caracteres(es)")
                .MaximumLength(50).WithMessage("El campo Apellido Paterno debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(x => x.SecondLastName)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Apellido Materno no debe ser nulo")
                .NotEmpty().WithMessage("El campo Apellido Materno no debe ser vacio")
                .MinimumLength(3).WithMessage("El campo Apellido Materno debe ser mayor o igual a {MinLength} caracteres. Ha ingresado {TotalLength} caracteres(es)")
                .MaximumLength(50).WithMessage("El campo Apellido Materno debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(x => x.RFC)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo RFC no debe ser nulo")
                .NotEmpty().WithMessage("El campo RFC no debe ser vacio")
                .MaximumLength(20).WithMessage("El campo RFC debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(x => x.GenderType)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("El campo Genero no debe ser nulo")
               .NotEmpty().WithMessage("El campo Genero no debe ser vacio");


            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El campo Correo no debe ser nulo")
                .NotEmpty().WithMessage("El campo Correo no debe ser vacio")
                .EmailAddress().WithMessage("El campo correo es invalido. El correo de ser como: example@.example.com")
                .MaximumLength(50).WithMessage("El campo correo debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");

            RuleFor(x => x.Address)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("El campo Domicilio no debe ser nulo")
               .NotEmpty().WithMessage("El campo Domicilio no debe ser vacio")
               .MaximumLength(150).WithMessage("El campo Domicilio debe ser menor a {MaxLength} caracteres. Ha ingresado {TotalLength} caracteres(es)");
        }
    }
}
