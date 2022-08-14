namespace MASA.OfficialWebsite.Shared.Pages;

public class AutoScrollComponentBase : ComponentBase, IAsyncDisposable
{
    [Inject]
    protected IJSRuntime Js { get; set; } = null!;

    [CascadingParameter(Name = "IsMobile")]
    protected bool IsMobile { get; set; }

    private bool _prevIsMobile;

    /// <summary>
    /// -1: disabled, 0: all, other
    /// </summary>
    protected virtual int? Page => IsMobile ? 1 : null;

    protected override async Task OnParametersSetAsync()
    {
        await base.OnParametersSetAsync();

        if (_prevIsMobile != IsMobile)
        {
            _prevIsMobile = IsMobile;

            await RemoveWindowScrollEvent();

            if (!IsMobile)
            {
                await AddWindowScrollEvent(Page);
            }
        }
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await base.OnAfterRenderAsync(firstRender);

        if (firstRender && !IsMobile)
        {
            await AddWindowScrollEvent(Page);
            StateHasChanged();
        }
    }

    protected async Task ScrollToNext()
    {
        await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
    }

    private ValueTask AddWindowScrollEvent(int? page)
    {
        return Js.InvokeVoidAsync("MasaOfficialWebsite.addWindowScrollEvent", page);
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
