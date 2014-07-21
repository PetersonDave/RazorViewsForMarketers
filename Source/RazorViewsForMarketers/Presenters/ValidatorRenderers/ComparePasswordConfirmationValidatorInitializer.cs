using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class ComparePasswordConfirmationValidatorInitializer : ValidatorInitializerBase<ComparePasswordConfirmationValidator>
    {
        public ComparePasswordConfirmationValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, ComparePasswordConfirmationValidator wffmValidator)
        {

        }

        public override void PopulateParameters(ComparePasswordConfirmationValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(ComparePasswordConfirmationValidator wffmValidator)
        {

        }
    }
}