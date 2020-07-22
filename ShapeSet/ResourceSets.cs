using Superset.Web.Resources;

namespace ShapeSet
{
    public static class ResourceSets
    {
        public static readonly ResourceSet ShapeSet =
            new ResourceSet("UISet." + nameof(ShapeSet), nameof(ShapeSet),
                stylesheets: new[] {"ShapeSet.css"});

        public static readonly ResourceSet BlazorErrorUIStyle =
            new ResourceSet("UISet." + nameof(ShapeSet), nameof(BlazorErrorUIStyle),
                stylesheets: new[] {"BlazorErrorUI.css"});

        public static readonly ResourceSet ComponentsReconnectModalStyle =
            new ResourceSet("UISet." + nameof(ShapeSet), nameof(ComponentsReconnectModalStyle),
                stylesheets: new[] {"ComponentsReconnectModal.css"});

        public static readonly ResourceSet SupersetValidationStyle =
            new ResourceSet("UISet." + nameof(ShapeSet), nameof(SupersetValidationStyle),
                stylesheets: new[] {"SupersetValidation.css"});

        public static readonly ResourceSet SupersetTooltipStyle =
            new ResourceSet("UISet." + nameof(ShapeSet), nameof(SupersetTooltipStyle),
                stylesheets: new[] {"SupersetTooltip.css"},
                dependencies: new[] {Superset.Web.ResourceSets.Tooltip});
    }
}