using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsSoloValidatorInitializer : ValidatorInitializerBase<IsSoloValidator>
    {
        public IsSoloValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsSoloValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsSoloValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsSoloValidator wffmValidator)
        {

        }
    }
}