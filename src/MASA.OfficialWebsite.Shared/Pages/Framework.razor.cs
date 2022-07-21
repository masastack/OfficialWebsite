using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class Framework
    {
        [Inject]
        private IJSRuntime Js { get; set; } = null!;

        [CascadingParameter(Name = "IsMobile")]
        private bool IsMobile { get; set; }

        private static readonly List<MenuableTitleItem> MenuableTitleItems = new()
        {
            new MenuableTitleItem("BuildingBlocks", "构建块", "#building-blocks-content"),
            new MenuableTitleItem("Utils", "通用类库集合", "#utils-content"),
            new MenuableTitleItem("Template", "项目模板", "#template-content"),
            new MenuableTitleItem("Why MASA Framework", "为什么选择MASA Framework?", "#why-masa-framework-content"),
        };

        private static readonly List<string> WhyContent1 = new()
        {
            "能力 - 架构不限",
            "标准 - 面向接口编程",
            "配置 - 可配置，遵循约定优于配置",
            "组合 - 全功能按需引用",
            "开放 - 所有能力都可被任意替换"
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
