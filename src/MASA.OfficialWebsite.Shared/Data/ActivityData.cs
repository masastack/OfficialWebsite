namespace MASA.OfficialWebsite.Shared.Data;

public static class ActivityData
{
    public static readonly List<Activity> AllActivities = new()
    {
        new Activity(
            "2023年成都.NET线下技术沙龙",
            "MASA技术团队来成都啦！",
            "https://cdn.masastack.com/images/activity_cd_230415.png",
            "https://cdn.masastack.com/images/m_activity_cd_230415.png",
            new DateTime(2023, 4, 15, 13, 30, 0),
            4,
            ActivityProduct.None,
            ActivityType.Meetup,
            ActivityMode.Offline,
            "meetup-230415"),
        new Activity(
            "2023年深圳.NET线下技术沙龙",
            "MASA技术团队来深圳啦！",
            "https://cdn.masastack.com/images/activity_sz_230318.png",
            "https://cdn.masastack.com/images/m_activity_sz_230318.svg",
            new DateTime(2023, 3, 18, 13, 30, 0),
            4,
            ActivityProduct.None,
            ActivityType.Meetup,
            ActivityMode.Offline,
            "meetup-230318"),
        new Activity(
            "MASA Stack 1.0 发布会",
            "MASA技术团队年终巨献，开启.NET生态新篇章",
            "https://cdn.masastack.com/images/activity_1.0.png",
            "https://cdn.masastack.com/images/m_activity_1.0.svg",
            new DateTime(2023, 1, 16, 14, 0, 0),
            4,
            ActivityProduct.Stack,
            ActivityType.ProductLaunching,
            ActivityMode.Online,
            "v1-launching"),
        new Activity(
            "MASA Framework实战课程开课",
            "大咖云集，共同助力",
            "https://cdn.masastack.com/images/activity2.jpg",
            "https://cdn.masastack.com/images/m_activity2.jpg",
            new DateTime(2022, 7, 22, 14, 0, 0),
            2,
            ActivityProduct.Framework,
            ActivityType.Training,
            ActivityMode.Online,
            "training-launching")
    };

    public static readonly Dictionary<string, ActivityDetail> AllActivityDetails = new()
    {
        {
            "training-launching",
            new Models.ActivityDetail("//player.bilibili.com/player.html?aid=343814267&bvid=BV1h94y1D7tw&cid=783315594&page=1&high_quality=1",
                "https://cdn.masastack.com/images/m_activity22.jpg",
                "https://cdn.masastack.com/images/m_activity22.jpg",
                "https://cdn.masastack.com/files/1.%20MASA%20Framework%E7%9A%84%E8%AE%BE%E8%AE%A1%E7%90%86%E5%BF%B5.pdf")
        },
        {
            "v1-launching",
            new Models.ActivityDetail("//player.bilibili.com/player.html?aid=392957693&bvid=BV1pd4y1V7qh&cid=969406701&page=1",
                "https://cdn.masastack.com/images/activity_detail_1.0.svg",
                "https://cdn.masastack.com/images/m_activity_detail_1.0.svg",
                null)
        },
        {
            "meetup-230318",
            new Models.ActivityDetail("//player.bilibili.com/player.html?aid=993829754&bvid=BV1Cx4y1w7kU&cid=1062779954&page=1",
                "https://cdn.masastack.com/images/activity_detail_sz_230318.png",
                "https://cdn.masastack.com/images/m_activity_detail_sz_230318.png",
                null)
        },
        {
            "meetup-230415",
            new Models.ActivityDetail(null,
                "https://cdn.masastack.com/images/activity_detail_cd_230415.png",
                "https://cdn.masastack.com/images/m_activity_detail_cd_230415.png",
                null)
        }
    };

    public static Activity LatestActivity => AllActivities.OrderByDescending(u => u.StartAt).First();

    public static List<Activity> Latest5Activities => AllActivities.OrderByDescending(u => u.StartAt).Take(5).ToList();
}
