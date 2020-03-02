using System;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Superset.Web.State;

namespace ColorSet.Components
{
    public class ThemeLoader
    {
        private readonly string               _defaultVariant;
        private readonly ILocalStorageService _localStorage;
        private readonly UpdateTrigger        _update = new UpdateTrigger();

        public ThemeLoader(ILocalStorageService localStorage, string[] prefixes, string defaultVariant)
        {
            _localStorage   = localStorage;
            Prefixes        = prefixes;
            _defaultVariant = defaultVariant;
        }

        public string       Variant  { get; private set; }
        public string[]     Prefixes { get; }
        public bool         Complete { get; private set; }
        public event Action OnComplete;

        public RenderFragment RenderLink()
        {
            void Fragment(RenderTreeBuilder builder)
            {
                int seq = -1;

                builder.OpenComponent<TriggerWrapper>(++seq);
                builder.AddAttribute(++seq, "Trigger", _update);
                builder.AddAttribute(++seq, "ChildContent", (RenderFragment) (builder2 =>
                {
                    foreach (string prefix in Prefixes)
                    {
                        builder2.AddMarkupContent(++seq, $"<!-- Prefix: {prefix}; Variant: {Variant} -->");
                        builder2.OpenElement(++seq, "link");
                        builder2.AddAttribute(++seq, "rel",  "stylesheet");
                        builder2.AddAttribute(++seq, "type", "text/css");
                        builder2.AddAttribute(++seq, "href", $"{prefix}/Style.{Variant}.css");
                        builder2.CloseElement();
                    }
                }));
                builder.CloseComponent();
            }

            return Fragment;
        }

        public async Task Load()
        {
            var variant = await _localStorage.GetItemAsync<string>("theme");
            if (string.IsNullOrEmpty(variant))
            {
                Variant = _defaultVariant;
                await _localStorage.SetItemAsync("theme", Variant);
            }
            else
            {
                Variant = variant;
            }

            _update.Trigger();
            Complete = true;
            OnComplete?.Invoke();
        }

        public RenderFragment RenderDropdown()
        {
            void Fragment(RenderTreeBuilder builder)
            {
                int seq = -1;

                builder.OpenElement(++seq, "div");
                builder.AddAttribute(++seq, "id", "ColorSet_ThemeLoader_Menu");

                builder.OpenElement(++seq, "span");

                builder.OpenElement(++seq, "label");
                builder.AddAttribute(++seq, "for", "ColorSet_ThemeLoader_Dropdown");
                builder.AddContent(++seq, "Theme");
                builder.CloseElement();

                builder.OpenComponent<TriggerWrapper>(++seq);
                builder.AddAttribute(++seq, "Trigger", _update);
                builder.AddAttribute(++seq, "ChildContent", (RenderFragment) (builder2 =>
                {
                    builder2.OpenElement(++seq, "select");
                    builder2.AddAttribute(++seq, "id", "ColorSet_ThemeLoader_Dropdown");
                    builder2.AddAttribute(++seq, "onchange",
                        EventCallback.Factory.Create<ChangeEventArgs>(this, OnThemeSelection));
                    foreach (string theme in Specs.Themes)
                    {
                        builder2.OpenElement(++seq, "option");
                        builder2.AddAttribute(++seq, "selected", Variant == theme);
                        builder2.AddContent(++seq, theme);
                        builder2.CloseElement();
                    }

                    builder2.CloseElement();
                }));
                builder.CloseComponent();

                builder.CloseElement();

                builder.CloseElement();
            }

            return Fragment;
        }

        private async Task OnThemeSelection(ChangeEventArgs args)
        {
            var variant = args.Value.ToString();
            Variant = variant;
            await _localStorage.SetItemAsync("theme", Variant);
            _update.Trigger();
        }
    }
}