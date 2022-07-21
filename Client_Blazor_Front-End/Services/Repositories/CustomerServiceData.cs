using DTOs;
using Models;
using Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace Services.Repositories
{
    public class CustomerServiceData : ICustomerServiceData
    {
        private readonly HttpClient _httpClient;
        public CustomerServiceData(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async ValueTask<ResponseClient<int>> AddCustomerAsync(CustomerEntity customer)
        {
            var customerJson = 
                new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("createCustomer", customerJson); 

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<ResponseClient<int>>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async ValueTask<ResponseClient<int>> DeleteCustomerAsync(int customerId)
        {
            var response = await _httpClient.DeleteAsync($"deleteCustomer/{customerId}");
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<ResponseClient<int>>(await response.Content.ReadAsStreamAsync());
            }
            return null;
        }

        public async ValueTask<ResponseClient<CustomerDTO>> DetailCustomerAsync(int customerId)
        {
            return await JsonSerializer.DeserializeAsync<ResponseClient<CustomerDTO>>
               (await _httpClient.GetStreamAsync($"getCustomers/{customerId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async ValueTask<ResponseClient<int>> EditCustomerAsync(CustomerDTO customerDTO)
        {
            var customerJson =
                 new StringContent(JsonSerializer.Serialize(customerDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("updateCustomer", customerJson); 

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<ResponseClient<int>>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async ValueTask<ResponseClient<List<CustomerDTO>>> GetCustomersListAsync()
        {
            var result = new ResponseClient<List<CustomerDTO>>();
            try
            {
                result = await JsonSerializer.DeserializeAsync<ResponseClient<List<CustomerDTO>>>
                        (await _httpClient.GetStreamAsync("getCustomersList"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });  //api/getCustomersList
            }
            catch (HttpRequestException ex)
            {

                Console.WriteLine( "status code: "+ ex.StatusCode); 
            }

            return result;
        }
    }
}
