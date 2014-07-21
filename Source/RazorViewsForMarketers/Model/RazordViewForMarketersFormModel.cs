using RazorViewsForMarketers.Models;

namespace RazorViewsForMarketers.Model
{
    public class RazordViewForMarketersFormModel
    {
        public Sitecore.Data.Fields.TextField Title { get; set; }
        public string SubmitMessage { get; set; }
        public WffmForm Form { get; set; }
    }
}