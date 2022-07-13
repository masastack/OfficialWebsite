using Masa.Blazor;
using Microsoft.AspNetCore.Components;

namespace MASA.OfficialWebsite.Shared.Components;

public class Menu : MMenu
{
    public override Task SetParametersAsync(ParameterView parameters)
    {
        OpenOnClick = true;
        Left = true;
        OffsetY = true;
        ContentClass = "menu-content";

        return base.SetParametersAsync(parameters);
    }
}
