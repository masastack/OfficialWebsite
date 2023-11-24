using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MASA.OfficialWebsite.WebApp.Components.Pages;

public class AutoScrollComponentBase : ComponentBase
{
    [Inject]
    protected IJSRuntime Js { get; set; } = null!;

    [CascadingParameter(Name = "IsMobile")]
    protected bool IsMobile { get; set; }

    protected async Task ScrollToNext()
    {
        await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
    }
}
