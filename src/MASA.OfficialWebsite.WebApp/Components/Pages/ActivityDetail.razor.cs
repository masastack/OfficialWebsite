using MASA.OfficialWebsite.WebApp.Models;
using Microsoft.AspNetCore.Components;
using static MASA.OfficialWebsite.WebApp.Data.ActivityData;

namespace MASA.OfficialWebsite.WebApp.Components.Pages;

public partial class ActivityDetail
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    [CascadingParameter(Name = "IsMobile")]
    private bool IsMobile { get; set; }

    [Parameter]
    public string Id { get; set; } = null!;

    private static readonly List<MenuableTitleItem> s_menuableTitleItems = new()
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
