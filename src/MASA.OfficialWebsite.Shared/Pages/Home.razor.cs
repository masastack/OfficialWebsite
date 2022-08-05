namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Home : AutoScrollComponentBase
{
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

    private StringNumber _carouselValue = 0;

    private StringNumber BannerMaxSize => IsMobile ? 375 : 874;
}
