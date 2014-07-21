using Blade.Razor;
using RazorViewsForMarketers.Model;

namespace RazorViewsForMarketers.Helpers
{
    public static class BladeExtensions
    {
        public static BladeHtmlHelper<RazordViewForMarketersFormModel> BladeHelper(this RazorRendering<RazordViewForMarketersFormModel> form)
        {
            return new BladeHtmlHelper<RazordViewForMarketersFormModel>(form);
        }
    }
}