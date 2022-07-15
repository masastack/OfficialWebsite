using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Home : IAsyncDisposable
{
    [Inject]
    private IJSRuntime Js { get; set; } = null!;

    private static readonly List<Activity> Activities = new()
    {
        new Activity("MASA Stack 社区例会", "MASA Stack最新进度汇报",
            "_content/MASA.OfficialWebsite.Shared/images/activity1.png",
            DateTime.Now, 2, ActivityType.Live),
        new Activity("MASA Stack 社区例会", "MASA Stack最新进度汇报",
            "_content/MASA.OfficialWebsite.Shared/images/activity1.png",
            DateTime.Now, 3, ActivityType.Offline),
        new Activity("MASA Stack 社区例会", "MASA Stack最新进度汇报",
            "_content/MASA.OfficialWebsite.Shared/images/activity1.png",
            DateTime.Now, 1, ActivityType.LookBack),
    };

    private bool _prevIsMobile;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (_prevIsMobile != IsMobile)
        {
            _prevIsMobile = IsMobile;

            await ResetWindowScrollEvent();
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender)
        {
            await AddWindowScrollEvent();
            StateHasChanged();
        }
    }

    private async Task ScrollToNext()
    {
        await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
    }

    private async Task ResetWindowScrollEvent()
    {
        await RemoveWindowScrollEvent();
        await AddWindowScrollEvent();
    }

    private ValueTask AddWindowScrollEvent()
    {
        return Js.InvokeVoidAsync("MasaOfficialWebsite.addWindowScrollEvent", IsMobile);
    }

    private ValueTask RemoveWindowScrollEvent()
    {
        return Js.InvokeVoidAsync("MasaOfficialWebsite.removeWindowScrollEvent");
    }

    public async ValueTask DisposeAsync()
    {
        try
        {
            await RemoveWindowScrollEvent();
        }
        catch (Exception e)
        {
            // ignored
        }
    }
}
