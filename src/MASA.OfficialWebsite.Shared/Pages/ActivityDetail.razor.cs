using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class ActivityDetail
    {
        [Inject]
        private IJSRuntime Js { get; set; } = null!;

        [CascadingParameter(Name = "IsMobile")]
        private bool IsMobile { get; set; }

        private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
        {
            new MenuableTitleItem("活动详情", "", "#activity-detail"),
            new MenuableTitleItem("视频回放", "", "#activity-video"),
            new MenuableTitleItem("资料下载", "", "#active-file"),
        };

        private async Task ScrollToNext()
        {
            await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
        }
    }
}
