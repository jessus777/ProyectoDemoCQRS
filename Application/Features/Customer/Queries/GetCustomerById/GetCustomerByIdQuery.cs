using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<Response<Domain.Entities.Customer>>
    {
        public int Id { get; set; }
    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Response<Domain.Entities.Customer>>
    {
        private readonly ICustomerRepositoryAsync _customerRepository;
        public GetCustomerByIdQueryHandler(ICustomerRepositoryAsync customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Response<Domain.Entities.Customer>> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(query.Id);

            if (customer is null)
            {
                return new Response<Domain.Entities.Customer> { Message = "No se encontro el cliente", Succeeded = false };
            }

            return new Response<Domain.Entities.Customer>(customer) ;

        }
    }
}
