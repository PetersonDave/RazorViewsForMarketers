using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using RazorViewsForMarketers.Models.Fields;

namespace RazorViewsForMarketers.Helpers
{
    public static class ValidatorHelper
    {
        public static MvcHtmlString RequiredIndicator<HackThePlanetModel>(this BladeHtmlHelper<HackThePlanetModel> helper, Func<HackThePlanetModel, WffmField> selector)
        {
            var field = selector(helper.View.Model);
            return field.IsRequired ? MvcHtmlString.Create("*") : null;
        }

        public static MvcHtmlString SitecoreLabel<HackThePlanetModel>(this BladeHtmlHelper<HackThePlanetModel> helper, HtmlHelper<HackThePlanetModel> help, Func<HackThePlanetModel, WffmField> selector)
        {
            var field = selector(helper.View.Model);
            return Sitecore.Context.PageMode.IsPageEditor ? MvcHtmlString.Create(Sitecore.Web.UI.WebControls.FieldRenderer.Render(field.Item, "Title")) : help.LabelFor(model => field.Response, field.Title);
        }
    }
}