using Microsoft.AspNetCore.Components;

namespace Client_Blazor_Front_End.Components.Spinner
{
    public partial class SpinnerComponent
    {
        [Parameter]
        public string StyleSpinner { get; set; } = "display:block;";
    }
}
