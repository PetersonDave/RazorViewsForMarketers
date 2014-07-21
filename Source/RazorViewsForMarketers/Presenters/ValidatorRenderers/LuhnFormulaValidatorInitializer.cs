using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class LuhnFormulaValidatorInitializer : ValidatorInitializerBase<LuhnFormulaValidator>
    {
        public LuhnFormulaValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, LuhnFormulaValidator wffmValidator)
        {

        }

        public override void PopulateParameters(LuhnFormulaValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(LuhnFormulaValidator wffmValidator)
        {

        }
    }
}