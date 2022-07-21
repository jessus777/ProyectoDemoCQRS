using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models;
using Validators;

namespace Client_Blazor_Front_End.Pages.Customer.CustomerComponents.Detail
{
    public partial class CustomerDetailComponent
    {
        [Parameter]
        public string CustomerId { get; set; }
        public CustomerEntity Customers { get; set; } = new CustomerEntity();

        CustomerDTOValidator Form1Validator = new CustomerDTOValidator();

        [Inject]
        IJSRuntime JsRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
            //await JsRuntime.InvokeVoidAsync("ShowSelect2Demo");
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync("ShowSelect2Demo");
        }

        void Send()
        {

        }
    }
}
