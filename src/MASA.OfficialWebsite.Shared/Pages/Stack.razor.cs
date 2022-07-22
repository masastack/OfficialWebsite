using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class Stack
    {
        [Inject]
        private IJSRuntime Js { get; set; } = null!;

        [CascadingParameter(Name = "IsMobile")]
        private bool IsMobile { get; set; }

        private static readonly List<string> WhyContent1 = new()
        {
            ".NET应用交付“保姆级”护航",
            "性能指标强悍，可担当电商、物联网等大流量场景的坚实底座",
            "支持任意板块可替换",
            "富含软件工程实践、项目管理方法论"
        };

        private static readonly List<string> WhyContent2 = new()
        {
            "全职开源团队，快速响应",
            "MIT协议，可放心商用",
            "微软代码规范，欢迎共同维护"
        };

        private static readonly List<string> WhyContent3 = new()
        {
            "多位.NET领域大咖推荐",
            "共同引领微软技术生态",
            "开放的社区",
            "定期社区例会，线上线下Meetup互动"
        };

        private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
        {
            new MenuableTitleItem("Basic Ability", "现代应用治理解决方案", "#basic-ability-content"),
            new MenuableTitleItem("Operator", "高效运维解决方案", "#operator-content"),
            new MenuableTitleItem("Data Factory", "数据治理解决方案", "#data-factory-content"),
            new MenuableTitleItem("Why MASA Stack", "为什么选择MASA Stack?", "#why-masa-statck-content"),
        };

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                await ResetWindowScrollEvent();
                StateHasChanged();
            }
        }

        private async Task ScrollToNext()
        {
            await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
        }

        private async Task ResetWindowScrollEvent()
        {
            await RemoveWindowScrollEvent();
            await AddWindowScrollEvent();
        }

        private ValueTask AddWindowScrollEvent()
        {
            return Js.InvokeVoidAsync("MasaOfficialWebsite.addWindowScrollEvent", true);
        }

        private ValueTask RemoveWindowScrollEvent()
        {
            return Js.InvokeVoidAsync("MasaOfficialWebsite.removeWindowScrollEvent");
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                await RemoveWindowScrollEvent();
            }
            catch (Exception e)
            {
                // ignored
            }
        }
    }
}
