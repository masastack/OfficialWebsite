namespace MASA.OfficialWebsite.Shared.Shared;

public partial class MainLayout
{
    private static readonly List<NavMenu.NavItem> ProductNavItems = new()
    {
        new NavMenu.NavItem("产品中心"),
        new NavMenu.NavItem("MASA Stack", "开源企业级云原生技术底座 PaasS", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png", "/stack"),
        new NavMenu.NavItem("MASA Framework", ".NET下一代微服务开发框架", "_content/MASA.OfficialWebsite.Shared/images/framework_logo.png", "/framework"),
        new NavMenu.NavItem("MASA Blazor", "打造企业级多端组件库", "_content/MASA.OfficialWebsite.Shared/images/blazor_logo.png", "/blazor"),
        new NavMenu.NavItem("解决方案"),
        new NavMenu.NavItem("MASA Cloud", "下一代商业软件平台", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png"),
        new NavMenu.NavItem("传统 .NET 架构升级", "传统.NET中大型项目升级宝典", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png"),
        new NavMenu.NavItem("MASA IoT", "通过连接2.0助力数字化转型", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png"),
    };

    private static readonly List<NavMenu.NavItem> StudyNavItems = new()
    {
        new NavMenu.NavItem("学习中心"),
        new NavMenu.NavItem("学习路径", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png"),
        new NavMenu.NavItem("学习路径", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png"),
        new NavMenu.NavItem("学习路径", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png"),
        new NavMenu.NavItem("学习路径", "https://cdn.masastack.com/stack/images/logo/MASAStack/logo.png"),
    };

    private static List<NavMenu.NavItem> AllNavItems => ProductNavItems.Concat(StudyNavItems).ToList();

    private void NavigateToAboutUs()
    {
        NavigationManager.NavigateTo("/about-us");
    }

    private bool IsMobile => MasaBlazor.Breakpoint.Mobile;

    private int IconSize => IsMobile ? 40 : 60;
}
