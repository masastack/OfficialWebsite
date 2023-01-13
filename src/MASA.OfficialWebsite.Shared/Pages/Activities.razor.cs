namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Activities : AutoScrollComponentBase
{
    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;

    private int _page = 1;

    private int _year = -1;

    private ActivityType _type = ActivityType.All;

    private List<Item<int>> _yearItems = new()
    {
        new Item<int>("全部", -1),
        new Item<int>("2023", 2023),
        new Item<int>("2022", 2022)
    };

    private List<Item<ActivityType>> _activityTypeItems = new()
    {
        new Item<ActivityType>("全部", ActivityType.All),
        new Item<ActivityType>("社区例会", ActivityType.CommunityMeeting),
        new Item<ActivityType>("产品发布会", ActivityType.ProductLaunching),
        new Item<ActivityType>("培训", ActivityType.Training),
        new Item<ActivityType>("线下聚会", ActivityType.Meetup),
    };

    private static readonly List<Activity> s_allActivities = new()
    {
        new Activity(
            "MASA Stack 1.0 发布会",
            "MASA技术团队年终巨献，开启.NET生态新篇章",
            "https://cdn.masastack.com/images/activity_1.0.png",
            "https://cdn.masastack.com/images/activity_detail_1.0.png",
            new DateTime(2023, 1, 16, 14, 0, 0),
            4,
            ActivityType.ProductLaunching,
            "v1-launching"),
        new Activity(
            "MASA Framework实战课程开课",
            "大咖云集，共同助力",
            "https://cdn.masastack.com/images/activity2.jpg",
            "https://cdn.masastack.com/images/m_activity2.jpg",
            new DateTime(2022, 7, 22, 14, 0, 0),
            2,
            ActivityType.Training,
            "training-launching")
    };

    private Activity LatestActivity => s_allActivities.OrderByDescending(u => u.StartAt).First();

    private List<Activity> Latest5Activities => s_allActivities.OrderByDescending(u => u.StartAt).Take(5).ToList();

    private IEnumerable<Activity> FilteredActivities
        => s_allActivities.Where(u => (_year == -1 || u.StartAt.Year == _year) && (_type == ActivityType.All || u.Type == _type))
                          .OrderByDescending(u => u.StartAt);

    private StringNumber _carouselValue = 0;

    private void CheckActivity(int index)
    {
        _carouselValue = index;
    }

    private void GoToDetail(string? id)
    {
        if (id is null)
        {
            return;
        }

        NavigationManager.NavigateTo($"/activityDetail/{id}", false);
    }
}

public class Item<T>
{
    public string Label { get; set; }
    public T Value { get; set; }

    public Item(string label, T value)
    {
        Label = label;
        Value = value;
    }
}
