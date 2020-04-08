using System.Threading;
using System.Threading.Tasks;

namespace SampleApp.Pages
{
    public partial class Index
    {
        protected override void OnInitialized()
        {
         // var x =   Microsoft.AspNetCore.Components.RenderTree.Renderer.InvokeRenderCompletedCallsAfterUpdateDisplayTask;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Thread.Sleep(100);
            Crash();
        }
    }
}