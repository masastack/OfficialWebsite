using Microsoft.AspNetCore.Components.Web;

namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Home : AutoScrollComponentBase
{
    private static readonly List<Activity> Activities = new()
    {
        new Activity(
            "MASA Stack 1.0 发布会",
            "MASA技术团队年终巨献，开启.NET生态新篇章",
            "https://cdn.masastack.com/images/activity_1.0.png",
            "",
            new DateTime(2023, 1, 16, 14, 0, 0),
            4,
            ActivityType.ProductLaunching,
            "v1-launching"),
        new Activity(
            "MASA Framework实战课程开课",
            "大咖云集，共同助力",
            "https://cdn.masastack.com/images/activity2.jpg",
            "",
            new DateTime(2022, 7, 22, 14, 0, 0),
            2,
            ActivityType.Training,
            "training-launching")
    };

    private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
    {
        new MenuableTitleItem("产品", "Modern App & Service Architecture", "#product-content"),
        new MenuableTitleItem("最新活动", "最新社区活动预告与往期回顾", "#activity-content"),
    };

    private double _startX;
    private double _deltaX;
    private double _offsetX;
    private string? _direction;

    private StringNumber _carouselValue = 0;

    private StringNumber BannerMaxSize => IsMobile ? 375 : 874;

    private void OnTouchstart(TouchEventArgs args)
    {
        ResetTouchStatus();
        _startX = args.Touches[0].ClientX;
    }

    private void OnTouchmove(TouchEventArgs args)
    {
        var touch = args.Touches[0];
        _deltaX = touch.ClientX < 0 ? 0 : touch.ClientX - _startX;
        _offsetX = Math.Abs(_deltaX);

        const int lockDirectionDistance = 10;
        if (string.IsNullOrEmpty(_direction) || _offsetX < lockDirectionDistance)
        {
            _direction = _deltaX < 0 ? "left2right" : "right2left";
        }
    }

    private void OnTouchend(TouchEventArgs args)
    {
        switch (_direction)
        {
            case "left2right":
            {
                var nextValue = _carouselValue.ToInt32() + 1;
                _carouselValue = nextValue > 2 ? 0 : nextValue;
                break;
            }
            case "right2left":
            {
                var prevValue = _carouselValue.ToInt32() - 1;
                _carouselValue = prevValue < 0 ? 2 : prevValue;
                break;
            }
        }
    }

    private void ResetTouchStatus()
    {
        _direction = "";
        _startX = 0;
        _deltaX = 0;
        _offsetX = 0;
    }
}
