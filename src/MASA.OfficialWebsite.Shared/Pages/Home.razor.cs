using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Home : IAsyncDisposable
{
    [Inject]
    private IJSRuntime Js { get; set; } = null!;

    [CascadingParameter(Name = "IsMobile")]
    private bool IsMobile { get; set; }

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

    private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
    {
        new MenuableTitleItem("产品", "Modern App & Service Architecture", "#product-content"),
        new MenuableTitleItem("最新活动", "最新社区活动预告与往期回顾", "#activity-content"),
    };

    private bool _prevIsMobile;
    private bool _haveRendered;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (_haveRendered && _prevIsMobile != IsMobile)
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
            _haveRendered = true;
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
