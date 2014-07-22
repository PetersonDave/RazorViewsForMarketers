using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.ValidatorRenderers
{
    public class GenericValidatorInitializer : ValidatorInitializerBase<GenericValidatorModel>
    {
        public GenericValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, GenericValidatorModel wffmValidator)
        {

        }

        public override void PopulateParameters(GenericValidatorModel wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(GenericValidatorModel wffmValidator)
        {

        }
    }
}