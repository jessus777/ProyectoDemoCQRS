using Microsoft.AspNetCore.Components;

namespace Client_Blazor_Front_End.Pages.Customer
{
    public partial class PageCustomerDetail
    {
        [Parameter]
        public string CustomerId { get; set; }
    }
}
