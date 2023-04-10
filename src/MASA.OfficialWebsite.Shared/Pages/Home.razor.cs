﻿using Microsoft.AspNetCore.Components.Web;

namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Home : AutoScrollComponentBase
{
    private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
    {
        new MenuableTitleItem("产品", "Modern App & Service Architecture", "#product-content"),
        new MenuableTitleItem("最新活动", "最新社区活动预告与往期回顾", "#activity-content"),
        new MenuableTitleItem("企业服务", "提供开源商业优质服务", "#service-content"),
    };
    
    private static readonly List<(string Major, string? Minor)> WhyContent1 = new()
    {
        ("部署安装服务", null),
        ("线上故障修复", null),
        ("服务巡检", null),
        ("专属服务沟通群", null),
    };

    private static readonly List<(string Major, string? Minor)> WhyContent2 = new()
    {
        ("基础架构类", "如上云、架构升级、DevOps集成等"),
        ("外包服务类", "如应用现代化重构、物联网、电商项目等"),
    };

    private static readonly List<(string Major, string? Minor)> WhyContent3 = new()
    {
        ("定制化培训服务", null),
        ("标准课程培训（初级、中级、高级、架构师）", null),
        ("外聘讲师培训", null),
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
