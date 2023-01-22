namespace MASA.OfficialWebsite.Shared.Pages
{
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

        private static readonly Dictionary<string, Data> s_activityDatas = new()
        {
            {
                "training-launching",
                new Data("//player.bilibili.com/player.html?aid=343814267&bvid=BV1h94y1D7tw&cid=783315594&page=1&high_quality=1",
                    "https://cdn.masastack.com/images/m_activity22.jpg",
                    "https://cdn.masastack.com/images/m_activity22.jpg",
                    "https://cdn.masastack.com/files/1.%20MASA%20Framework%E7%9A%84%E8%AE%BE%E8%AE%A1%E7%90%86%E5%BF%B5.pdf")
            },
            {
                "v1-launching",
                new Data("//player.bilibili.com/player.html?aid=222878030&bvid=BV1E8411A78X&cid=969400545&page=1",
                    "https://cdn.masastack.com/images/activity_detail_1.0.svg",
                    "https://cdn.masastack.com/images/m_activity_detail_1.0.svg",
                    null)
            }
        };

        private Data? _data;

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            _data = s_activityDatas.GetValueOrDefault(Id);
        }

        private void DownLoadFiles(string uri)
        {
            NavigationManager.NavigateTo(uri, false);
        }

        private class Data
        {
            public Data(string cover, string mobileCover)
            {
                Cover = cover;
                MobileCover = mobileCover;
            }

            public Data(string? video, string cover, string mobileCover, string? file) : this(cover, mobileCover)
            {
                Video = video;
                File = file;
            }

            public string? Video { get; init; }
            public string? Cover { get; init; }
            public string? MobileCover { get; init; }
            public string? File { get; init; }
        }
    }
}
