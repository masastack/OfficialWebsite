using Masa.Blazor;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;

namespace MASA.OfficialWebsite.Shared.Shared;

public partial class MainLayout : IDisposable
{
    private static readonly List<NavMenu.NavItem> s_productNavItems = new()
    {
        new NavMenu.NavItem("产品中心"),
        new NavMenu.NavItem("MASA Stack", "开源企业级开发者门户 平台工程", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png", "/stack", 30),
        new NavMenu.NavItem("MASA Framework", ".NET下一代微服务开发框架", "https://cdn.masastack.com/images/framework_logo.png", "/framework", 30),
        new NavMenu.NavItem("MASA Blazor", "打造企业级多端组件库", "https://cdn.masastack.com/images/blazor_logo.png", "/blazor", 30),
        new NavMenu.NavItem("解决方案"),
        new NavMenu.NavItem("MASA Cloud", "下一代商业软件平台", "https://cdn.masastack.com/images/bule-dot.svg", null, 12, true),
        new NavMenu.NavItem("传统 .NET 架构升级", "传统.NET中大型项目升级宝典", "https://cdn.masastack.com/images/bule-dot.svg", null, 12, true),
        new NavMenu.NavItem("MASA IoT", "通过连接2.0助力数字化转型", "https://cdn.masastack.com/images/bule-dot.svg", null, 12, true),
    };

    private static readonly List<NavMenu.NavItem> s_studyNavItems = new()
    {
        new NavMenu.NavItem("学习中心"),
        new NavMenu.NavItem("学习路径", "", "https://cdn.masastack.com/images/bule-dot.svg", "/learningpath", 12),
        new NavMenu.NavItem("博客站点", "", "https://cdn.masastack.com/images/bule-dot.svg", "https://blogs.masastack.com", 12),
        new NavMenu.NavItem("文档站点", "", "https://cdn.masastack.com/images/bule-dot.svg", "https://docs.masastack.com", 12),
        new NavMenu.NavItem("社区活动", "", "https://cdn.masastack.com/images/bule-dot.svg", "/activity", 12),
    };

    private static readonly List<NavMenu.NavItem> s_aboutUsItems = new()
    {
        new NavMenu.NavItem("关于我们"),
        new NavMenu.NavItem("关于我们", "", "https://cdn.masastack.com/images/bule-dot.svg", "/aboutus", 12)
    };

    private static List<NavMenu.NavItem> AllNavItems => s_productNavItems.Concat(s_studyNavItems).Concat(s_aboutUsItems).ToList();

    private static readonly List<string> s_excludeRoutes = new() { "/learningpath" };

    private static readonly string[] s_products = { "stack", "framework", "blazor" };

    private bool? _drawer;
    private double _startY;
    private double _deltaY;
    private double _offsetY;
    private string? _direction;
    private bool _isMobile;
    private string? _currentAbsolutePath;

    private int IconSize => _isMobile ? 40 : 60;

    private int WeChatSize => _isMobile ? 120 : 200;

    private int NudgeLeft => WeChatSize / 2 - IconSize / 2;

    private bool PreventTouch => !_isMobile || (_currentAbsolutePath is not null && s_excludeRoutes.Contains(_currentAbsolutePath));

    private bool _isShow;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _isMobile = MasaBlazor.Breakpoint.Mobile;

        MasaBlazor.MobileChanged += MasaBlazorOnMobileChanged;

        NavigationManager.LocationChanged += NavigationManagerOnLocationChanged;

        ResolveLocation();
    }

    private void MasaBlazorOnMobileChanged(object? sender, MobileChangedEventArgs e)
    {
        _isMobile = MasaBlazor.Breakpoint.Mobile;
        InvokeAsync(StateHasChanged);
    }

    private void NavigationManagerOnLocationChanged(object? sender, LocationChangedEventArgs e)
    {
        var isProductPage = ResolveLocation();

        if (_isShow != isProductPage)
        {
            _isShow = isProductPage;

            InvokeAsync(StateHasChanged);
        }
    }

    private bool ResolveLocation()
    {
        _currentAbsolutePath = NavigationManager.GetAbsolutePath();
        return s_products.Any(p => _currentAbsolutePath.StartsWith($"/{p}"));
    }

    private string ComputedHref
    {
        get
        {
            var href = NavigationManager.Uri;

            if (href.EndsWith("/stack"))
            {
                return "https://docs.masastack.com/stack/stack/introduce";
            }

            if (href.EndsWith("/framework"))
            {
                return "https://docs.masastack.com/framework/concepts/overview";
            }

            if (href.EndsWith("/blazor"))
            {
                return "https://docs.masastack.com/blazor/getting-started/installation";
            }

            return "https://docs.masastack.com";
        }
    }

    protected void OnTouchstart(TouchEventArgs args)
    {
        if (PreventTouch) return;

        ResetTouchStatus();
        _startY = args.Touches[0].ClientY;
    }

    protected void OnTouchmove(TouchEventArgs args)
    {
        if (PreventTouch) return;

        var touch = args.Touches[0];
        _deltaY = touch.ClientY < 0 ? 0 : touch.ClientY - _startY;
        _offsetY = Math.Abs(_deltaY);

        const int lockDirectionDistance = 10;
        if (string.IsNullOrEmpty(_direction) || _offsetY < lockDirectionDistance)
        {
            if (_offsetY > 50)
            {
                _direction = _deltaY < 0 ? "top2bottom" : "bottom2top";
            }
        }
    }

    protected async Task OnTouchend(TouchEventArgs args)
    {
        if (PreventTouch) return;

        switch (_direction)
        {
            case "top2bottom":
            {
                await ScrollToNextForTouch();
                break;
            }
            case "bottom2top":
            {
                await ScrollToPrevForTouch();
                break;
            }
        }
    }

    protected async Task ScrollToNextForTouch()
    {
        await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNextForTouch");
    }

    protected async Task ScrollToPrevForTouch()
    {
        await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToPrevForTouch");
    }

    private void ResetTouchStatus()
    {
        _direction = "";
        _startY = 0;
        _deltaY = 0;
        _offsetY = 0;
    }

    public void Dispose()
    {
        MasaBlazor.MobileChanged -= MasaBlazorOnMobileChanged;
        NavigationManager.LocationChanged -= NavigationManagerOnLocationChanged;
    }
}
