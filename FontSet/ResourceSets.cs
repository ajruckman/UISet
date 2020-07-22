using Superset.Web.Resources;

namespace FontSet
{
    public static class ResourceSets
    {
        public static ResourceSet Inter =
            new ResourceSet("UISet." + nameof(FontSet), nameof(Inter),
                stylesheets: new[] {"Inter.css"});

        public static ResourceSet JetBrainsMono =
            new ResourceSet("UISet." + nameof(FontSet), nameof(JetBrainsMono),
                stylesheets: new[] {"JetBrainsMono.css"});

        public static ResourceSet Roboto =
            new ResourceSet("UISet." + nameof(FontSet), nameof(Roboto),
                stylesheets: new[] {"Roboto.css"});

        public static ResourceSet RobotoMono =
            new ResourceSet("UISet." + nameof(FontSet), nameof(RobotoMono),
                stylesheets: new[] {"RobotoMono.css"});
    }
}