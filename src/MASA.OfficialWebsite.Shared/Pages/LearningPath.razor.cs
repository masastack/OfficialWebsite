namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class LearningPath
    {
        [Inject]
        private IJSRuntime Js { get; set; } = null!;

        [CascadingParameter(Name = "IsMobile")]
        private bool IsMobile { get; set; }

        private async Task ScrollToNext()
        {
            await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
        }
    }
}
