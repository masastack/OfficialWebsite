using Masa.Blazor;
using Microsoft.AspNetCore.Components;

namespace MASA.OfficialWebsite.WebApp.Components.Pages;

public class AutoScrollComponentBase : ComponentBase
{
    [Inject]
    private MasaBlazor MasaBlazor { get; set; } = null!;

    protected bool IsMobile => MasaBlazor.Breakpoint.Mobile;
}
