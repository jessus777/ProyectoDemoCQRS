
namespace Application.Features.Customer.Commands.EditCustomer
{
    public class EditCustomerCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string RFC { get; set; }
        public GenderType GenderType { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, Response<int>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        public EditCustomerCommandHandler(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;   
        }


        public async Task<Response<int>> Handle(EditCustomerCommand command, CancellationToken cancellationToken)
        {
            var validatorCustomerEdit = new EditCustomerCommandValidator();
            var resultValidator = await validatorCustomerEdit.ValidateAsync(command, cancellationToken);
            if (!resultValidator.IsValid)
            {
                List<string> errors = new();
                errors.AddRange(resultValidator.Errors.Select(error => error.ErrorMessage));
                return new Response<int>(null) { Message = "No se puedo Actualizar" , Succeeded= false, Errors= errors};
            }

            var isUniqueCustomer = await _customerRepository.IsUniqueCustomerAsync(command.Email);
            var customer = new Domain.Entities.Customer();
            if (isUniqueCustomer)
            {
               
                customer = (Domain.Entities.Customer)DataMapper.Parse(command, new Domain.Entities.Customer());
                await _customerRepository.UpdateAsync(customer);
            }
            else
            {
               var newCustomer = new Domain.Entities.Customer()
                                { 
                                  Name = command.Name,
                                  SecondName= command.SecondName,
                                  FirstLastName = command.FirstLastName,
                                  SecondLastName = command.SecondLastName,
                                  RFC = command.RFC,
                                  GenderType = command.GenderType,
                                  Email = command.Email,
                                  Address = command.Address
                                };
                await _customerRepository.AddAsync(newCustomer);
                return new Response<int>(customer.Id) { Message = "Se guardo correctamente", Succeeded = true };
            }

            return new Response<int>(customer.Id) { Message = "Se actualizo correctamente", Succeeded = true };
        }
    }
}
