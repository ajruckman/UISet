using System.Collections.Generic;
using ShapeSet;
using Superset.Web.Resources;

namespace SampleApp
{
    internal sealed class Configuration
    {
        public readonly List<ResourceManifest> Manifests;

        public Configuration()
        {
            Manifests = new List<ResourceManifest>
            {
                FontSet.ResourceManifests.Inter,
                FontSet.ResourceManifests.JetBrainsMono,
                ShapeSet.ResourceManifests.ShapeSet,
                ShapeSet.ResourceManifests.BlazorErrorUIStyle,
                ColorSet.ResourceManifests.Globals,

                Superset.Web.ResourceManifests.LocalCSS,
                
            };
        }
    }
}