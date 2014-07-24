using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace RazorViewsForMarketers.Models.Fields
{
    public class DropListField : WffmField
    {
        public IList<ListItem> Items { get; set; }
        public string SelectedValue { get; set; }
    }
}