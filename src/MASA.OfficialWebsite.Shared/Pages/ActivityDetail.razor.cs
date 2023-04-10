using static MASA.OfficialWebsite.Shared.Data.ActivityData;

namespace MASA.OfficialWebsite.Shared.Pages;

public partial class ActivityDetail
{
    [Inject]
    private IJSRuntime Js { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [CascadingParameter(Name = "IsMobile")]
    private bool IsMobile { get; set; }

    [Parameter]
    public string Id { get; set; } = null!;

    private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
    {
        new MenuableTitleItem("视频回放", "", "#activity-video"),
        new MenuableTitleItem("活动详情", "", "#activity-detail"),
        new MenuableTitleItem("资料下载", "", "#active-file"),
    };

    private Models.ActivityDetail? _data;

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        _data = AllActivityDetails.GetValueOrDefault(Id);
    }

    private void DownLoadFiles(string uri)
    {
        NavigationManager.NavigateTo(uri, false);
    }
}