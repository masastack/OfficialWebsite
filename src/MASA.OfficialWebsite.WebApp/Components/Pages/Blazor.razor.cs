namespace MASA.OfficialWebsite.WebApp.Components.Pages;

public partial class Blazor : AutoScrollComponentBase
{
    private string BannerMaxSize => IsMobile ? "375px" : "874px";
}
