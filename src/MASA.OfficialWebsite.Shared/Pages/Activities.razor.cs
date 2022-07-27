using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class Activities
    {
        [Inject]
        private IJSRuntime Js { get; set; } = null!;

        [CascadingParameter(Name = "IsMobile")]
        private bool IsMobile { get; set; }

        private int _page = 1;

        private int _year = 2022;

        private int _activityType = 0;

        private ActivityType? _channel = null;

        private List<Item<int>> yearItems = new()
        {
            new Item<int>("2022", 2022),
            new Item<int>("2021", 2021),
            new Item<int>("2020", 2020),
            new Item<int>("2019", 2019)
        };

        private List<Item<int>> activityTypeItems = new()
        {
            new Item<int>("社区例会", 1),
            new Item<int>("产品发布会", 2),
            new Item<int>("培训", 3),
            new Item<int>("Meetup", 4),
        };

        private List<Item<ActivityType>> channelItems = new()
        {
            new Item<ActivityType>("线上直播", ActivityType.Live),
            new Item<ActivityType>("线下", ActivityType.Offline),
            new Item<ActivityType>("回放", ActivityType.LookBack)
        };

        private StringNumber _carouselValue = 0;
        private async Task ScrollToNext()
        {
            await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
        }

        private static readonly List<Activity> AllActivities = new()
        {
            new Activity("MASA Blazor 社区例会", "基于Material Design , MAUI的最佳拍档",
                "_content/MASA.OfficialWebsite.Shared/images/activity2.jpg",
                DateTime.Now, 2, ActivityType.Live),
            new Activity("MASA Blazor 社区例会", "基于Material Design , MAUI的最佳拍档",
                "_content/MASA.OfficialWebsite.Shared/images/activity2.jpg",
                DateTime.Now.AddDays(-1), 3, ActivityType.Offline),
            new Activity("MASA Blazor 社区例会", "基于Material Design , MAUI的最佳拍档",
                "_content/MASA.OfficialWebsite.Shared/images/activity2.jpg",
                DateTime.Now.AddDays(-2), 1, ActivityType.LookBack),
            new Activity("MASA Blazor 社区例会", "基于Material Design , MAUI的最佳拍档",
                "_content/MASA.OfficialWebsite.Shared/images/activity2.jpg",
                DateTime.Now.AddDays(-3), 2, ActivityType.Live),
            new Activity("MASA Blazor 社区例会", "基于Material Design , MAUI的最佳拍档",
                "_content/MASA.OfficialWebsite.Shared/images/activity2.jpg",
                DateTime.Now.AddDays(-4), 3, ActivityType.Offline),
            new Activity("MASA Blazor 社区例会", "基于Material Design , MAUI的最佳拍档",
                "_content/MASA.OfficialWebsite.Shared/images/activity2.jpg",
                DateTime.Now.AddYears(-1), 1, ActivityType.LookBack)
        };

        private void CheckActivity(EventArgs eventargs, int index)
        {
            _carouselValue = index;
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
}
