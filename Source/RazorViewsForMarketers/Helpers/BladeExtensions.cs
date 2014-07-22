using Blade.Razor;
using RazorViewsForMarketers.Models;

namespace RazorViewsForMarketers.Helpers
{
    public static class BladeExtensions
    {
        public static BladeHtmlHelper<RazorViewForMarketersFormModel> BladeHelper(this RazorRendering<RazorViewForMarketersFormModel> form)
        {
            return new BladeHtmlHelper<RazorViewForMarketersFormModel>(form);
        }
    }
}