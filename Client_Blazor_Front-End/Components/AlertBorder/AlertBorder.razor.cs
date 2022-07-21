using Microsoft.AspNetCore.Components;
namespace Client_Blazor_Front_End.Components.AlertBorder
{
    public partial class AlertBorder
    {
        [Parameter]
        public string Class { get; set; }
        [Parameter]
        public RenderFragment ChildContent { get; set; }

    }
}

