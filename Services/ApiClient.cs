namespace Services
{
    public class ApiClient
    {
        const string CreateOrderEndpoint = "create";
        readonly HttpClient HttpClient;

        public ApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }


    }
}
