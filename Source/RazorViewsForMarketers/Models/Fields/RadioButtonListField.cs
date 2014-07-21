namespace RazorViewsForMarketers.Models.Fields
{
    public class RadioButtonListField : WffmField
    {
        public string Items { get; set; }
        public string SelectedValue { get; set; }
        public string Columns { get; set; }
        public string Direction { get; set; }
    }
}