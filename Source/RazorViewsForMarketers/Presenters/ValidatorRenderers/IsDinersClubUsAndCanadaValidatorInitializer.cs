using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class IsDinersClubUsAndCanadaValidatorInitializer : ValidatorInitializerBase<IsDinersClubUsAndCanadaValidator>
    {
        public IsDinersClubUsAndCanadaValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, IsDinersClubUsAndCanadaValidator wffmValidator)
        {

        }

        public override void PopulateParameters(IsDinersClubUsAndCanadaValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(IsDinersClubUsAndCanadaValidator wffmValidator)
        {

        }
    }
}