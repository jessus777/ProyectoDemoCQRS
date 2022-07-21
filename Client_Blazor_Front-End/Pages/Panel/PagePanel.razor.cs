using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Client_Blazor_Front_End.Pages.Panel
{
    public partial class PagePanel
    {
        [Inject]
        IJSRuntime JsRuntime { get; set; }

        protected async override Task OnInitializedAsync()
        {
           
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await JsRuntime.InvokeVoidAsync("graphCustomer");
            await JsRuntime.InvokeVoidAsync("graphCustomer3");
        }
    }
}
