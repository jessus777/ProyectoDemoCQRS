using Microsoft.AspNetCore.Components;
using Services.Interfaces;
using Microsoft.JSInterop;
using DTOs;

namespace Client_Blazor_Front_End.Pages.Customer.CustomerComponents.List
{

    public partial class CustomersList
    {
        [Inject]
        protected ICustomerServiceData CustomerServiceAsync { get; set; }
        [Inject]
        public IJSRuntime JsRuntime { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected bool Success { get; set; } = false;
        protected string Message { get; set; } = string.Empty;

        protected List<CustomerDTO> Customers = new List<CustomerDTO>();

        public List<string> Errors { get; set; } = new List<string>();

        protected bool SuccesListCustomer { get; set; } = true;

        protected override async Task OnInitializedAsync()
        {

            var response = await CustomerServiceAsync.GetCustomersListAsync();
            if (response.Succeeded)
            {
                Customers = new List<CustomerDTO>();
                Customers.AddRange(response.Data);
            }
            else
            {
                SuccesListCustomer = false;
                if (!string.IsNullOrEmpty(response.Message))
                {
                    Message = response.Message;
                }
                if (response.Errors != null)
                {
                    if (response.Errors.Count > 0)
                    {
                        Errors.AddRange(response.Errors);
                    }
                }
                

            }
            //await JsRuntime.InvokeVoidAsync("spinnerLoadingHide");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {               
                await GetDatatbles();
                await JsRuntime.InvokeVoidAsync("spinnerLoadingHide");
            }

        }

        private async Task Delete(string CustomerId, string name)
        {

            int.TryParse(CustomerId, out int customerId );
            if (customerId <= 0)
            {
                await JsRuntime.InvokeVoidAsync("confirmAlert", "error", "#dc3545", "Error", "Los campos no se pudieron eliminar!");
            }
            else
            {
                var resultConfirm = await JsRuntime.InvokeAsync<bool>("showAlertQuestionAsync", false, "¿Estás Seguro?", $"Sé eliminaran los datos de: {name}", "Sí, eliminar", "cancelar");
                if (resultConfirm)
                {
                    await JsRuntime.InvokeVoidAsync("spinnerLoadingShow");
                    var deleteCustomerAsync = await CustomerServiceAsync.DeleteCustomerAsync(customerId);
                    if (deleteCustomerAsync.Succeeded)
                    {
                        
                        await JsRuntime.InvokeVoidAsync("confirmAlert", "success", "#198754", "Eliminado!", "Los campos se han elimanado correctamente!");
                        await JsRuntime.InvokeVoidAsync("spinnerLoadingHide");

                        var response = await CustomerServiceAsync.GetCustomersListAsync();
                        if (response.Succeeded)
                        {
                            Customers = new List<CustomerDTO>();
                            Customers.AddRange(response.Data);
                        }

                        NavigateToListCustomer();
                    }
                    else
                    {
                        await JsRuntime.InvokeVoidAsync("spinnerLoadingHide");
                    }
                   
                }

            }

        }

        protected void NavigateToListCustomer()
        {
            NavigationManager.NavigateTo("/customers",true);
        }

        protected async Task GetDatatbles()
        {
            await JsRuntime.InvokeVoidAsync("dataTable");
        }

    }
}
