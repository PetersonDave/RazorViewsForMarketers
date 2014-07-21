namespace RazorViewsForMarketers.Models.Fields
{
    public class CreditCardField : WffmField
    {
        public string CardTypeTitle { get; set; }
        public string CardNumberTitle { get; set; }
        public string CardTypeHelp { get; set; }
        public string CardNumberHelp { get; set; }
        public string CardTypesQuery { get; set; }
    }
}