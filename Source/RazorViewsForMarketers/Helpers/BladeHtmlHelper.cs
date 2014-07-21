using Blade.Razor;

namespace RazorViewsForMarketers.Helpers
{
    public class BladeHtmlHelper<HackThePlanetModel>
    {
        public BladeHtmlHelper(RazorRendering<HackThePlanetModel> view)
        {
            View = view;
        }

        public RazorRendering<HackThePlanetModel> View { get; private set; }
    }
}