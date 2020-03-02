using Superset.Web.Resources;

namespace FontSet
{
    public static class ResourceManifests
    {
        public static ResourceManifest Inter =
            new ResourceManifest("UISet." + nameof(FontSet), stylesheets: new[] {"Inter.css"});

        public static ResourceManifest JetBrainsMono =
            new ResourceManifest("UISet." + nameof(FontSet), stylesheets: new[] {"JetBrainsMono.css"});

        public static ResourceManifest Roboto =
            new ResourceManifest("UISet." + nameof(FontSet), stylesheets: new[] {"Roboto.css"});

        public static ResourceManifest RobotoMono =
            new ResourceManifest("UISet." + nameof(FontSet), stylesheets: new[] {"RobotoMono.css"});
    }
}