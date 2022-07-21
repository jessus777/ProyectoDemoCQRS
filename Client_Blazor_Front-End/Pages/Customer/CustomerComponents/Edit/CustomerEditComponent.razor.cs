using Client_Blazor_Front_End.Models;
using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Services.Interfaces;
using Validators;

namespace Client_Blazor_Front_End.Pages.Customer.CustomerComponents.Edit
{
    public partial class CustomerEditComponent
    {
        [Parameter]
        public string CustomerId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        protected ICustomerServiceData CustomerServiceAsync { get; set; }

        CustomerEditValidator CustomerEditValidator = new CustomerEditValidator();

        [Inject]
        IJSRuntime JSRuntime { get; set; }

        protected CustomerEditEntity CustomerEdit { get; set; }  = new CustomerEditEntity();
        public CustomerDTO CustomerDTO { get; set; } = new CustomerDTO();



        protected override async Task OnInitializedAsync()
        {

            int.TryParse(CustomerId, out var customerId);
            if (customerId > 0)
            {
                var detailCustomerAsync = await CustomerServiceAsync.DetailCustomerAsync(customerId);
                if (detailCustomerAsync.Succeeded)
                {
                    CustomerDTO = detailCustomerAsync.Data;
                }
            }    
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.InvokeVoidAsync("spinnerLoadingHide");

            }
        }

        private async Task SendEdit()
        {
            var resultConfirm = await JSRuntime.InvokeAsync<bool>("showAlertQuestionAsync", true, "¿Estás Seguro?", "Sé guardarán los datos capturados", "Sí, guardar", "cancelar");
            if (resultConfirm)
            {
                await JSRuntime.InvokeVoidAsync("spinnerLoadingShow");
                var addCustomerAsync = await CustomerServiceAsync.EditCustomerAsync(CustomerDTO);
                if (addCustomerAsync.Succeeded)
                {
                    CustomerDTO = new CustomerDTO();
                    await JSRuntime.InvokeVoidAsync("spinnerLoadingHide");
                    await JSRuntime.InvokeVoidAsync("confirmAlert", "success", "#198754", "Editado!", "Los campos se han guardado correctamente!");
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
                CustomerDTO = new CustomerDTO();

                await JSRuntime.InvokeVoidAsync("confirmAlert", "success", "#198754", "Limpiado", "Los campos se han limpiado correctamente!");

            }
        }

        protected void NavigateToListCustomer()
        {
            NavigationManager.NavigateTo("/customers");
        }

    }
}
