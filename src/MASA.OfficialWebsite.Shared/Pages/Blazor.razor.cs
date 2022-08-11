using Microsoft.AspNetCore.Components.Web;

namespace MASA.OfficialWebsite.Shared.Pages;

public partial class Blazor : AutoScrollComponentBase
{
    private double _startX;
    private double _deltaX;
    private double _offsetX;
    private string? _direction;

    protected override int? Page => 1;

    private StringNumber _carouselValue = 0;

    private StringNumber BannerMaxSize => IsMobile ? 375 : 874;

    [Inject]
    private IJSRuntime JSRuntime { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync("setTitle", "MASA Blazor - 企业级多端组件库");
    }

    private void OnTouchstart(TouchEventArgs args)
    {
        ResetTouchStatus();
        _startX = args.Touches[0].ClientX;
    }

    private void OnTouchmove(TouchEventArgs args)
    {
        var touch = args.Touches[0];
        _deltaX = touch.ClientX < 0 ? 0 : touch.ClientX - _startX;
        _offsetX = Math.Abs(_deltaX);

        const int lockDirectionDistance = 10;
        if (string.IsNullOrEmpty(_direction) || _offsetX < lockDirectionDistance)
        {
            _direction = _deltaX < 0 ? "left2right" : "right2left";
        }
    }

    private void OnTouchend(TouchEventArgs args)
    {
        switch (_direction)
        {
            case "left2right":
            {
                var nextValue = _carouselValue.ToInt32() + 1;
                _carouselValue = nextValue > 1 ? 0 : nextValue;
                break;
            }
            case "right2left":
            {
                var prevValue = _carouselValue.ToInt32() - 1;
                _carouselValue = prevValue < 0 ? 1 : prevValue;
                break;
            }
        }
    }

    private void ResetTouchStatus()
    {
        _direction = "";
        _startX = 0;
        _deltaX = 0;
        _offsetX = 0;
    }
}
