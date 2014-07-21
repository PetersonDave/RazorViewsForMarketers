using System;
using System.Web.Mvc;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace RazorViewsForMarketers.Helpers
{
    public static class TextHelpers
    {
        public static MvcHtmlString TextFor<HackThePlanetModel>(this BladeHtmlHelper<HackThePlanetModel> helper, Func<HackThePlanetModel, TextField> selector)
        {
            return TextFor(helper, selector, true);
        }

        public static MvcHtmlString TextFor<HackThePlanetModel>(this BladeHtmlHelper<HackThePlanetModel> helper, Func<HackThePlanetModel, TextField> selector, bool editable)
        {
            var field = selector(helper.View.Model);

            if (!string.IsNullOrEmpty(field.InnerField.Value) || helper.View.IsEditing)
            {
                if (editable)
                {
                    var raw = FieldRenderer.Render(field.InnerField.Item, field.InnerField.ID.ToString());
                    return MvcHtmlString.Create(raw);
                }
            }

            var content = FieldRenderer.Render(field.InnerField.Item, field.InnerField.ID.ToString());
            return MvcHtmlString.Create(content);
        }
    }
}