using Superset.Web.Resources;

namespace ColorSet
{
    public static class ResourceSets
    {
        public static readonly ResourceSet Globals = new ResourceSet(
            "UISet." + nameof(ColorSet),
            nameof(Globals),
            stylesheets: new[] {"css/Globals.{{ThemeVariant}}.css"}
        );
    }
}