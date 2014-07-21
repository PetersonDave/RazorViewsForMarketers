using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsMaestroValidatorInitializer : ValidatorInitializerBase<IsMaestroValidator>
    {
        public IsMaestroValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsMaestroValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsMaestroValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsMaestroValidator wffmValidator)
        {

        }
    }
}