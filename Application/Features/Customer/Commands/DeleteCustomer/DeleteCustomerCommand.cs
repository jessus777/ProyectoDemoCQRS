using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

    }

    public class DeleteCustomerCommandCommandHandler : IRequestHandler<DeleteCustomerCommand, Response<int>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        public DeleteCustomerCommandCommandHandler(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Response<int>> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var validatorCustomerDelete = new DeleteCustomerCommandValidator();
            var resultValidator = await validatorCustomerDelete.ValidateAsync(command, cancellationToken);
            List<string> errors = new();
            if (!resultValidator.IsValid)
            {
                errors.AddRange(resultValidator.Errors.Select(error => error.ErrorMessage));
                return new Response<int>{ Message = "No se puedo Eliminar", Succeeded = false, Errors = errors };
            }

            var customer = await _customerRepository.GetCustomerByIdAsync(command.Id);

            if (customer == default)
            {
                errors.Add("No se encontró el Cliente con ese Id");
                return new Response<int>(null) { Message = "No se puedo Eliminar", Succeeded = false, Errors= errors };
            }

            await _customerRepository.DeleteAsync(customer);

            return new Response<int>(customer.Id) { Message = "Se elimino correctamente", Succeeded = true };
        }
    }
}
