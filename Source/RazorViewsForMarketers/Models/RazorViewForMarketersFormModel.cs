namespace RazorViewsForMarketers.Models
{
    public class RazorViewForMarketersFormModel
    {
        public Sitecore.Data.Fields.TextField Title { get; set; }
        public string SubmitMessage { get; set; }
        public WffmForm Form { get; set; }
    }
}