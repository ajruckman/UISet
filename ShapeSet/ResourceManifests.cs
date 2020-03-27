using Superset.Web.Resources;

namespace ShapeSet
{
    public static class ResourceManifests
    {
        public static readonly ResourceManifest ShapeSet =
            new ResourceManifest("UISet." + nameof(ShapeSet), stylesheets: new[] {"ShapeSet.css"});
    }
}