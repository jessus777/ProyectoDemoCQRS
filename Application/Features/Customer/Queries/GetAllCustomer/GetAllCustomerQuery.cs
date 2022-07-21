using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Queries.GetAllCustomer
{
    public class GetAllCustomerQuery : IRequest<Response<IEnumerable<GetAllCustomerViewModel>>>
    {

    }
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQuery, Response<IEnumerable<GetAllCustomerViewModel>>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        public GetAllCustomerQueryHandler(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Response<IEnumerable<GetAllCustomerViewModel>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            var getCustomers = await _customerRepository.GetAllAsync();

            if (getCustomers == default || getCustomers.Count <= 0)
            {
                return new Response<IEnumerable<GetAllCustomerViewModel>>(null) { Succeeded = false, Message = "No hay Clientes" };
            }

            var customers = new List<GetAllCustomerViewModel>();
            foreach (var customer in getCustomers)
            {
                customers.Add((GetAllCustomerViewModel)DataMapper.Parse(customer, new GetAllCustomerViewModel()));
            }

            return new Response<IEnumerable<GetAllCustomerViewModel>>(customers);
        }
    }
}
