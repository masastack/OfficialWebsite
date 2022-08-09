namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class Blazor : AutoScrollComponentBase
    {
        protected override int? Page => 1;

        private StringNumber _carouselValue = 0;

        private StringNumber BannerMaxSize => IsMobile ? 375 : 874;
    }
}
