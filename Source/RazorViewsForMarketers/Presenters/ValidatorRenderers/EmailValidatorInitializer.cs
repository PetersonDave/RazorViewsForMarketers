using RazorViewsForMarketers.Models.Validators;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.ValidatorRenderers
{
    public class EmailValidatorInitializer : ValidatorInitializerBase<EmailValidator>
    {
        public EmailValidatorInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateValidatorFields(Item validatorItem, EmailValidator wffmValidator)
        {
            wffmValidator.ValidationExpression = validatorItem.Fields["Validation Expression"].Value;
        }

        public override void PopulateParameters(EmailValidator wffmValidator)
        {

        }

        public override void PopulateLocalizedParameters(EmailValidator wffmValidator)
        {

        }
    }
}