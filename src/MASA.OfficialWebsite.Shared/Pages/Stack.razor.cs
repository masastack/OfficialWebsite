using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace MASA.OfficialWebsite.Shared.Pages
{
    public partial class Stack : IAsyncDisposable
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
            "全职开源团队，代码规范，响应问题效率高",
            "文档齐全，文字视频相辅相成，学习路径明确，国际化程度高",
            "Apache 2.0协议，可放心用于商用场景",
            ".NET原生设计，魔改无压力"
        };
        private static readonly List<string> WhyContent3 = new()
        {
            "众多微软MVP顶力支持",
            "引领微软技术生态",
            "完备的社区管理",
            "定期社区例会，线上线下Meetup互动"
        };
        private async Task ScrollToNext()
        {
            await Js.InvokeVoidAsync("MasaOfficialWebsite.scrollToNext");
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

        private ValueTask RemoveWindowScrollEvent()
        {
            return Js.InvokeVoidAsync("MasaOfficialWebsite.removeWindowScrollEvent");
        }
    }
}
