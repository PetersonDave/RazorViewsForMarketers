namespace RazorViewsForMarketers.Helpers
{
    public abstract class BladeRazorRendering<TModel> : Blade.Razor.RazorRendering<TModel>
    {
        private BladeHtmlHelper<TModel> _htmlHelper;
        public BladeHtmlHelper<TModel> BladeHelper
        {
            get
            {
                if (_htmlHelper == null) _htmlHelper = new BladeHtmlHelper<TModel>(this);
                return _htmlHelper;
            }
        }
    }
}