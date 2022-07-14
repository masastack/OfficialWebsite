namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Home
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
}
