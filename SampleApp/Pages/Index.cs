using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Superset.Web.Markup;
using Superset.Web.Validation;

namespace SampleApp.Pages
{
    public partial class Index
    {
        private Validator<ValidationResult> _validator = new Validator<ValidationResult>();

        private ElementReference _tooltip;
        
        protected override void OnInitialized()
        {
            _validator.Register("input1_2", () => new []
            {
                new Validation<ValidationResult>(ValidationResult.Valid, "Valid"), 
            });

            _validator.Register("input2_2", () => new []
            {
                new Validation<ValidationResult>(ValidationResult.Warning, "Warning!"), 
                new Validation<ValidationResult>(ValidationResult.Valid, "Valid"), 
            });
            
            _validator.Register("input3_2", () => new []
            {
                new Validation<ValidationResult>(ValidationResult.Invalid, "Invalid!"), 
                new Validation<ValidationResult>(ValidationResult.Warning, "A pretty long warning notice goes here..."), 
                new Validation<ValidationResult>(ValidationResult.Valid, "Valid"), 
            });
            
            _validator.Validate();
            
         // var x =   Microsoft.AspNetCore.Components.RenderTree.Renderer.InvokeRenderCompletedCallsAfterUpdateDisplayTask;
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            Thread.Sleep(100);
            // Crash();

            if (!firstRender) return;
            
            Tooltip tooltip = new Tooltip(_tooltip, "Button");
            await tooltip.Execute(JSRuntime);
        }
    }
}