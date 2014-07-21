namespace RazorViewsForMarketers.Helpers
{
    public abstract class BladeRazorRenderingEditorTemplate<TModel> : Blade.Razor.RazorRendering<TModel>
    {
        private BladeHtmlHelper<TModel> _htmlHelper;
        public BladeHtmlHelper<TModel> BladeHtmlHelper
        {
            get
            {
                if (_htmlHelper == null) _htmlHelper = new BladeHtmlHelper<TModel>(this);
                return _htmlHelper;
            }
        }
    }
}