using Validators;
using FluentValidation;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Models;
using Services.Interfaces;
using Services.Repositories;

namespace Client_Blazor_Front_End
{
    public static class RegisterServicesData
    {
        public static WebAssemblyHostBuilder UseServicesData(
        this WebAssemblyHostBuilder builder)
        {

            builder.Services.AddHttpClient<ICustomerServiceData, CustomerServiceData>
                (client => client.BaseAddress = new Uri(builder.Configuration["WebApiUri"]));

            return builder;
        }

        public static WebAssemblyHostBuilder UseServicesValidation(
       this WebAssemblyHostBuilder builder)
        {
            // services.AddValidatorsFromAssemblyContaining<NestedForm>();
            //builder.Services.AddValidatorsFromAssemblyContaining<CustomerEntity>();
            return builder;
        }
    }
}
