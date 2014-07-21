using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class SuspiciousFormActivityValidatorInitializer : ValidatorInitializerBase<SuspiciousFormActivityValidator>
    {
        public SuspiciousFormActivityValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, SuspiciousFormActivityValidator wffmValidator)
        {

        }

        public override void PopulateParameters(SuspiciousFormActivityValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(SuspiciousFormActivityValidator wffmValidator)
        {

        }
    }
}