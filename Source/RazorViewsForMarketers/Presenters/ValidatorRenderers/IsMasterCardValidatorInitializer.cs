using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsMasterCardValidatorInitializer : ValidatorInitializerBase<IsMasterCardValidator>
    {
        public IsMasterCardValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsMasterCardValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsMasterCardValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsMasterCardValidator wffmValidator)
        {

        }
    }
}