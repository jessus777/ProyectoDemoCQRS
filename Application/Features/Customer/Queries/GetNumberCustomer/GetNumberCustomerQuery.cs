namespace Application.Features.Customer.Queries.GetNumberCustomer
{
    public class GetNumberCustomerQuery : IRequest<Response<int>>
    {

    }
    public class GetNumberCustomerQueryHandler : IRequestHandler<GetNumberCustomerQuery, Response<int>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        public GetNumberCustomerQueryHandler(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Response<int>> Handle(GetNumberCustomerQuery query, CancellationToken cancellationToken)
        {
            var numberDemo = await _customerRepository.GetNumberCustomerDemoAsync();
            return new Response<int>(numberDemo) { Message = $"Numero del cliente {numberDemo}", Succeeded = true };
        }
    }
}
