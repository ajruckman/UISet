using System.Collections.Generic;
using Superset.Web.Resources;

namespace SampleApp
{
    internal sealed class Configuration
    {
        public readonly List<ResourceManifest> Manifests;

        public readonly ResourceSet ResourceSet;

        public Configuration()
        {
            Manifests = new List<ResourceManifest>
            {
                FontSet.ResourceManifests.Inter,
                FontSet.ResourceManifests.JetBrainsMono,
                ShapeSet.ResourceManifests.ShapeSet,
                ShapeSet.ResourceManifests.BlazorErrorUIStyle,
                ShapeSet.ResourceManifests.ComponentsReconnectModalStyle,
                ShapeSet.ResourceManifests.SupersetValidationStyle,
                ShapeSet.ResourceManifests.SupersetTooltipStyle,
                ColorSet.ResourceManifests.Globals,

                Superset.Web.ResourceManifests.LocalCSS,
                Superset.Web.ResourceManifests.Tooltip
            };

            ResourceSet = new ResourceSet
            (
                nameof(SampleApp),
                nameof(ResourceSet),
                dependencies: new[]
                {
                    FontSet.ResourceSets.Inter,
                    FontSet.ResourceSets.JetBrainsMono,
                    ShapeSet.ResourceSets.ShapeSet,
                    ShapeSet.ResourceSets.BlazorErrorUIStyle,
                    ShapeSet.ResourceSets.ComponentsReconnectModalStyle,
                    ShapeSet.ResourceSets.SupersetValidationStyle,
                    ShapeSet.ResourceSets.SupersetTooltipStyle,
                    ColorSet.ResourceSets.Globals,
                    Superset.Web.ResourceSets.LocalCSS,
                }
            );
        }
    }
}