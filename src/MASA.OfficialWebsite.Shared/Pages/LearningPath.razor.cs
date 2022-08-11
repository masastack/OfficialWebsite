using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class LearningPath
    {
        [Inject]
        private IJSRuntime Js { get; set; } = null!;

        [CascadingParameter(Name = "IsMobile")]
        private bool IsMobile { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Js.InvokeVoidAsync("setTitle", "学习路径");
        }

        private async Task ScrollToNext()
        {
            await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
        }
    }
}
