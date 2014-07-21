using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsDinersClubInternationalValidatorInitializer : ValidatorInitializerBase<IsDinersClubInternationalValidator>
    {
        public IsDinersClubInternationalValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsDinersClubInternationalValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsDinersClubInternationalValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsDinersClubInternationalValidator wffmValidator)
        {

        }
    }
}