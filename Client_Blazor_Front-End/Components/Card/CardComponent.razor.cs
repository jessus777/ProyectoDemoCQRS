using Microsoft.AspNetCore.Components;

namespace Client_Blazor_Front_End.Components.Card
{
    public partial class CardComponent
    {
        [Parameter]
        public string Title { get; set; } = string.Empty;
        [Parameter]
        public RenderFragment ChildContent { get; set; }
        [Parameter]
        public string Class_mb { get; set; } = "3";
    }
}
