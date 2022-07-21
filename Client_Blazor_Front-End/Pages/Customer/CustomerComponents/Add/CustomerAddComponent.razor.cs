
using Validators;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models;
using Services.Interfaces;

namespace Client_Blazor_Front_End.Pages.Customer.CustomerComponents.Add
{
    public partial class CustomerAddComponent
    {
        public CustomerEntity Customers { get; set; } = new CustomerEntity();

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        protected ICustomerServiceData CustomerServiceAsync { get; set; }

        CustomerDTOValidator Form1Validator = new CustomerDTOValidator();
        [Inject]
        IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
           
            //int.TryParse(CustomerId, out var customerId);
            //if (customerId > 0)
            //{
            //    var detailCustomerAsync = await CustomerServiceAsync.DetailCustomerAsync(customerId);
            //    if (detailCustomerAsync.Succeeded)
            //    {
            //        //Customers = (CustomerEntity)detailCustomerAsync.Data;
            //    }
            //}
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("spinnerLoadingHide");

            }
            //await JSRuntime.InvokeVoidAsync("showToast");
        }

        private async Task Send()
        {
            var resultConfirm = await JSRuntime.InvokeAsync<bool>("showAlertQuestionAsync", true, "¿Estás Seguro?", "Sé guardarán los datos capturados", "Sí, guardar", "cancelar");
            if (resultConfirm)
            {
                await JSRuntime.InvokeVoidAsync("spinnerLoadingShow");
                var addCustomerAsync = await CustomerServiceAsync.AddCustomerAsync(Customers);
                if (addCustomerAsync.Succeeded)
                {
                    Customers = new CustomerEntity();
                    await JSRuntime.InvokeVoidAsync("spinnerLoadingHide");
                    await JSRuntime.InvokeVoidAsync("confirmAlert", "success", "#198754", "Guardado!", "Los campos se han guardado correctamente!");
                    NavigateToListCustomer();
                }
                else
                {
                    await JSRuntime.InvokeVoidAsync("spinnerLoadingHide");
                }
            }    
        }
        async Task ShowAlertCleanData()
        {

            var resultConfirm = await JSRuntime.InvokeAsync<bool>("showAlertWarning", "¿Estás Seguro?", "Sé limpiaran los campos capturados", "Sí, limpiar", "cancelar");
            if (resultConfirm)
            {
                Customers = new CustomerEntity();

                await JSRuntime.InvokeVoidAsync("confirmAlert", "success", "#198754", "Limpiado", "Los campos se han limpiado correctamente!");

            }
        }

        protected void NavigateToListCustomer()
        {
            NavigationManager.NavigateTo("/customers");
        }
    }
}
