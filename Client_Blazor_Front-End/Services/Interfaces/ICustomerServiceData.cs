using DTOs;
using Models;

namespace Services.Interfaces
{
    public interface ICustomerServiceData
    {
        ValueTask<ResponseClient<List<CustomerDTO>>> GetCustomersListAsync();
        ValueTask<ResponseClient<int>> AddCustomerAsync(CustomerEntity customer);
        ValueTask<ResponseClient<CustomerDTO>> DetailCustomerAsync(int customerId);
        ValueTask<ResponseClient<int>> EditCustomerAsync(CustomerDTO customerDTO);
        ValueTask<ResponseClient<int>> DeleteCustomerAsync(int customerId);
    }
}
