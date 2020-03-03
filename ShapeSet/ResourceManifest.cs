using Superset.Web.Resources;

namespace ShapeSet
{
    public static class ResourceManifests
    {
        public static ResourceManifest Composite = new ResourceManifest(
            nameof(ShapeSet),
            stylesheets: new[] {"css/Style.{{ThemeVariant}}.css"}
        );
    }
}