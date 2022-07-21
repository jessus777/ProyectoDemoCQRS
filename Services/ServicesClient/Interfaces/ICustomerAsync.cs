using Domain.Entities;
using Services.ServicesClient.Repositories;
using Services.Wappers;

namespace Services.ServicesClient.Interfaces
{
    public interface ICustomerAsync
    {
        ValueTask<int> GetNumberClientAsync();
        ValueTask<Customer> GetCustomerAsync(int id);

        ValueTask<ResponseClient<int>> GetNumberClientDemAsync();
    }
}
