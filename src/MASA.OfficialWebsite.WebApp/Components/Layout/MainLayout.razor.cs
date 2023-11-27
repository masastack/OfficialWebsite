using MASA.OfficialWebsite.WebApp.Components.Shared;
using MASA.OfficialWebsite.WebApp.Models;

namespace MASA.OfficialWebsite.WebApp.Components.Layout;

public partial class MainLayout
{
    private static readonly List<NavItem> s_productNavItems = new()
    {
        new NavItem("产品中心"),
        new NavItem("MASA Stack", "开源企业级开发者门户 平台工程", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png", "/stack", 30),
        new NavItem("MASA Framework", ".NET下一代微服务开发框架", "https://cdn.masastack.com/images/framework_logo.png", "/framework", 30),
        new NavItem("MASA Blazor", "打造企业级多端组件库", "https://cdn.masastack.com/images/blazor_logo.png", "/blazor", 30),
        new NavItem("解决方案"),
        new NavItem("MASA Cloud", "下一代商业软件平台", "https://cdn.masastack.com/images/bule-dot.svg", null, 12, true),
        new NavItem("传统 .NET 架构升级", "传统.NET中大型项目升级宝典", "https://cdn.masastack.com/images/bule-dot.svg", null, 12, true),
        new NavItem("MASA IoT", "通过连接2.0助力数字化转型", "https://cdn.masastack.com/images/bule-dot.svg", null, 12, true),
    };

    private static readonly List<NavItem> s_studyNavItems = new()
    {
        new NavItem("学习中心"),
        new NavItem("学习路径", "", "https://cdn.masastack.com/images/bule-dot.svg", "/learningpath", 12),
        new NavItem("博客站点", "", "https://cdn.masastack.com/images/bule-dot.svg", "https://blogs.masastack.com", 12),
        new NavItem("文档站点", "", "https://cdn.masastack.com/images/bule-dot.svg", "https://docs.masastack.com", 12),
        new NavItem("社区活动", "", "https://cdn.masastack.com/images/bule-dot.svg", "/activity", 12),
    };

    private static readonly List<NavItem> s_aboutUsItems = new()
    {
        new NavItem("关于我们"),
        new NavItem("关于我们", "", "https://cdn.masastack.com/images/bule-dot.svg", "/aboutus", 12)
    };

    private static List<NavItem> AllNavItems => s_productNavItems.Concat(s_studyNavItems).Concat(s_aboutUsItems).ToList();

    private static readonly List<string> s_excludeRoutes = new() { "/learningpath" };

    private static readonly string[] s_products = { "stack", "framework", "blazor" };

    private bool _isMobile;
    private bool _isShow;
    private bool? _drawer;

    private int IconSize => _isMobile ? 40 : 60;
    
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

    protected override void OnInitialized()
    {
        base.OnInitialized();

        _isMobile = MasaBlazor.Breakpoint.Mobile;

        Console.Out.WriteLine("MasaBlazor.Breakpoint.Mobile: " + MasaBlazor.Breakpoint.Mobile);
    }
}
