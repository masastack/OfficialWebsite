namespace MASA.OfficialWebsite.Shared.Shared;

public partial class MainLayout : IDisposable
{
    private static readonly List<NavMenu.NavItem> ProductNavItems = new()
    {
        new NavMenu.NavItem("产品中心"),
        new NavMenu.NavItem("MASA Stack", "开源企业级云原生技术底座 PaaS", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png", "/stack", 30),
        new NavMenu.NavItem("MASA Framework", ".NET下一代微服务开发框架", "_content/MASA.OfficialWebsite.Shared/images/framework_logo.png", "/framework", 30),
        new NavMenu.NavItem("MASA Blazor", "打造企业级多端组件库", "_content/MASA.OfficialWebsite.Shared/images/blazor_logo.png", "/blazor", 30),
        new NavMenu.NavItem("解决方案"),
        new NavMenu.NavItem("MASA Cloud", "下一代商业软件平台", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", null, 12, true),
        new NavMenu.NavItem("传统 .NET 架构升级", "传统.NET中大型项目升级宝典", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", null, 12, true),
        new NavMenu.NavItem("MASA IoT", "通过连接2.0助力数字化转型", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", null, 12, true),
    };

    private static readonly List<NavMenu.NavItem> StudyNavItems = new()
    {
        new NavMenu.NavItem("学习中心"),
        new NavMenu.NavItem("学习路径","", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", "/learningpath", 12),
        new NavMenu.NavItem("博客站点", "", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", "https://blogs.masastack.com", 12),
        new NavMenu.NavItem("文档站点","", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", "https://docs.masastack.com", 12),
        new NavMenu.NavItem("社区活动", "", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", "/activity", 12),
    };

    private static readonly List<NavMenu.NavItem> AboutUsItems = new()
    {
        new NavMenu.NavItem("关于我们"),
        new NavMenu.NavItem("关于我们","", "_content/MASA.OfficialWebsite.Shared/images/bule-dot.svg", "/aboutus", 12)
    };

    private static List<NavMenu.NavItem> AllNavItems => ProductNavItems.Concat(StudyNavItems).Concat(AboutUsItems).ToList();

    private bool _drawer;

    private bool IsMobile { get; set; }

    private int IconSize => IsMobile ? 40 : 60;
    private int WeChatSize => IsMobile ? 120 : 200;
    private int NudgeLeft => WeChatSize / 2 - IconSize / 2;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        IsMobile = MasaBlazor.Breakpoint.Mobile;

        MasaBlazor.Breakpoint.OnUpdate += BreakpointOnOnUpdate;
    }

    private Task BreakpointOnOnUpdate()
    {
        return InvokeAsync(() =>
        {
            IsMobile = MasaBlazor.Breakpoint.Mobile;
            StateHasChanged();
        });
    }

    public void Dispose()
    {
        MasaBlazor.Breakpoint.OnUpdate -= BreakpointOnOnUpdate;
    }
}
