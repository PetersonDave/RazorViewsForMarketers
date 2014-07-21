using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class RobotProtectionValidatorInitializer : ValidatorInitializerBase<RobotProtectionValidator>
    {
        public RobotProtectionValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, RobotProtectionValidator wffmValidator)
        {

        }

        public override void PopulateParameters(RobotProtectionValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(RobotProtectionValidator wffmValidator)
        {

        }
    }
}