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

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
        {
            new MenuableTitleItem("视频回放", "", "#activity-video"),
            new MenuableTitleItem("活动详情", "", "#activity-detail"),
            new MenuableTitleItem("资料下载", "", "#active-file"),
        };

        private async Task ScrollToNext()
        {
            await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
        }

        private void DownLoadFiles()
        {
            NavigationManager.NavigateTo("https://cdn.masastack.com/files/1.%20MASA%20Framework%E7%9A%84%E8%AE%BE%E8%AE%A1%E7%90%86%E5%BF%B5.pdf", false);
        }
    }
}
