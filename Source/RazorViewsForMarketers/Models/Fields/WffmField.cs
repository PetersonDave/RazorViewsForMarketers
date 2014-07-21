using System.Collections.Generic;
using RazorViewsForMarketers.Models.Validators;
using RazorViewsForMarketers.ValidatorAttributes;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Models.Fields
{
    public abstract class WffmField
    {
        public Item Item { get; set; }
        public IEnumerable<Validator> Validators { get; set; }
        public string ValidatorIds { get; set; }
        public string Title { get; set; }
        public bool IsRequired { get; set; }
        public string Help { get; set; }
        public string PredefinedValidatorPattern { get; set; }
        public string RegExPattern { get; set; }
        public string CssClass { get; set; }
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        public string Information { get; set; }
        public string Text { get; set; }

        [RuntimeRequired()]
        [RuntimeRegularExpression("RegExPattern", "The value you have entered is invalid")]
        [RuntimeValidation()]
        public string Response { get; set; }
        public string ModelType { get { return GetType().FullName; } }
    }
}