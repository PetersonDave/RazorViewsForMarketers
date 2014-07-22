using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.ValidatorRenderers
{
    public class GenericValidatorInitializer : ValidatorInitializerBase<GenericValidator>
    {
        public GenericValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, GenericValidator wffmValidator)
        {

        }

        public override void PopulateParameters(GenericValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(GenericValidator wffmValidator)
        {

        }
    }
}