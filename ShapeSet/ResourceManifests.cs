using Superset.Web.Resources;

namespace ShapeSet
{
    public static class ResourceManifests
    {
        public static readonly ResourceManifest ShapeSet =
            new ResourceManifest("UISet." + nameof(ShapeSet), stylesheets: new[] {"ShapeSet.css"});
        
        public static readonly ResourceManifest BlazorErrorUIStyle =
            new ResourceManifest("UISet." + nameof(ShapeSet), stylesheets: new[] {"BlazorErrorUI.css"});        
        
        public static readonly ResourceManifest ComponentsReconnectModalStyle =
            new ResourceManifest("UISet." + nameof(ShapeSet), stylesheets: new[] {"ComponentsReconnectModal.css"});
    }
}