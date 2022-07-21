using Domain.Entities;
using Services.ServicesClient.Interfaces;
using Services.Wappers;
using System.Text.Json;

namespace Services.ServicesClient.Repositories
{
    public class CustomerAsync : ICustomerAsync
    {
        private readonly HttpClient _httpClient;
      
        public CustomerAsync(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public ValueTask<Customer> GetCustomerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async ValueTask<int> GetNumberClientAsync()
        {
            //var response = new Response<int>(0) { Message = String.Empty, Succeeded = false };
            //return await JsonSerializer.DeserializeAsync<ResponseClient>
            //   (await _httpClient.GetStreamAsync("api/getCustomerNumber"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var algo = await _httpClient.GetAsync("api/getCustomerNumber");
            var content = await algo.Content.ReadAsStreamAsync();
            return 0;
        }

        public async ValueTask<ResponseClient<int>> GetNumberClientDemAsync()
        {

            var response = await JsonSerializer.DeserializeAsync<ResponseClient<int>>
                    (await _httpClient.GetStreamAsync("api/getCustomerNumber"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }
    }
}
