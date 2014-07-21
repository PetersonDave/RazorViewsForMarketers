using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsDinersClubCarteBlancheValidatorInitializer : ValidatorInitializerBase<IsDinersClubCarteBlancheValidator>
    {
        public IsDinersClubCarteBlancheValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsDinersClubCarteBlancheValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsDinersClubCarteBlancheValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsDinersClubCarteBlancheValidator wffmValidator)
        {

        }
    }
}