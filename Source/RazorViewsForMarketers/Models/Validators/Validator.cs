using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Models.Validators
{
    public abstract class Validator
    {
        public string ValidationExpression { get; set; }
        public string Assembly { get; set; }
        public string Class { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorText { get; set; }
        public string ValidatorDisplay { get; set; }
        public bool EnableClientScript { get; set; }
        public string AnalyticsFieldEvent { get; set; }
        public string Text { get; set; }
        public string ClientValidationFunction { get; set; }
        public Item Item { get; set; }
    }
}