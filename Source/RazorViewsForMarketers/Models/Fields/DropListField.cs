using System.Collections.Specialized;

namespace RazorViewsForMarketers.Models.Fields
{
    public class DropListField : WffmField
    {
        public NameValueCollection Items { get; set; }
        public string SelectedValue { get; set; }
    }
}