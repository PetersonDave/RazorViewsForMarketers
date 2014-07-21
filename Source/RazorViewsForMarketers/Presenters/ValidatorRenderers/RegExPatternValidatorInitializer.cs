using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class RegExPatternValidatorInitializer : ValidatorInitializerBase<RegExPatternValidator>
    {
        public RegExPatternValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, RegExPatternValidator wffmValidator)
        {

        }

        public override void PopulateParameters(RegExPatternValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(RegExPatternValidator wffmValidator)
        {

        }
    }
}