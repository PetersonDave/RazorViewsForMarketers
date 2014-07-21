using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class SuspiciousVisitorsValidatorInitializer : ValidatorInitializerBase<SuspiciousVisitorsValidator>
    {
        public SuspiciousVisitorsValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, SuspiciousVisitorsValidator wffmValidator)
        {

        }

        public override void PopulateParameters(SuspiciousVisitorsValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(SuspiciousVisitorsValidator wffmValidator)
        {

        }
    }
}