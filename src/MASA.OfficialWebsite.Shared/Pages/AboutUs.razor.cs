namespace MASA.OfficialWebsite.Shared.Pages;

public partial class AboutUs: AutoScrollComponentBase
{
    protected override int? Page => 1;

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync("setTitle", "数闪科技 - 让变化更简单");
    }
}