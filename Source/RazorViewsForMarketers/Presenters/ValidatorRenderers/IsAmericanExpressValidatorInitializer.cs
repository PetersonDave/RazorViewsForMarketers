using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsAmericanExpressValidatorInitializer : ValidatorInitializerBase<IsAmericanExpressValidator>
    {
        public IsAmericanExpressValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsAmericanExpressValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsAmericanExpressValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsAmericanExpressValidator wffmValidator)
        {

        }
    }
}