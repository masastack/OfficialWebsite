using Microsoft.AspNetCore.Components;

namespace MASA.OfficialWebsite.WebApp;

public static class NavigationManagerExtensions
{
    public static string GetRelativeUriWithQueryParameters(this NavigationManager navigationManager, IReadOnlyDictionary<string, object?> parameters)
    {
        var uriWithQueryParameters = navigationManager.GetUriWithQueryParameters(parameters);
        return navigationManager.ToRelativeUriWithQueryParameters(uriWithQueryParameters);
    }

    public static string GetRelativeUriWithQueryParameter(this NavigationManager navigationManager, string name, bool? value)
    {
        var uriWithQueryParameter = navigationManager.GetUriWithQueryParameter(name, value);
        return navigationManager.ToRelativeUriWithQueryParameters(uriWithQueryParameter);
    }

    public static string GetRelativeUriWithQueryParameter(this NavigationManager navigationManager, string name, string? value)
    {
        var uriWithQueryParameter = navigationManager.GetUriWithQueryParameter(name, value);
        return navigationManager.ToRelativeUriWithQueryParameters(uriWithQueryParameter);
    }

    private static string ToRelativeUriWithQueryParameters(this NavigationManager navigationManager, string absoluteUriWithQueryParameters)
    {
        var baseUri = navigationManager.BaseUri;
        var relativeUriWithQueryParameters = absoluteUriWithQueryParameters.Replace(baseUri, string.Empty);
        return relativeUriWithQueryParameters.StartsWith("/") ? relativeUriWithQueryParameters : "/" + relativeUriWithQueryParameters;
    }
}
