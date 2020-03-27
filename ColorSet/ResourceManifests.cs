using Superset.Web.Resources;

namespace ColorSet
{
    public static class ResourceManifests
    {
        public static readonly ResourceManifest Globals = new ResourceManifest(
            "UISet." + nameof(ColorSet),
            stylesheets: new[] {"css/Globals.{{ThemeVariant}}.css"}
        );
    }
}