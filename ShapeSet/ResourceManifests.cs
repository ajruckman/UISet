using Superset.Web.Resources;

namespace ShapeSet
{
    public static class ResourceManifests
    {
        public static readonly ResourceManifest Composite = new ResourceManifest(
            "UISet." + nameof(ShapeSet),
            stylesheets: new[] {"css/Style.{{ThemeVariant}}.css"}
        );
    }
}