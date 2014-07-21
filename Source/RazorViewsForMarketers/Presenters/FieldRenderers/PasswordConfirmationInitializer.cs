using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class PasswordConfirmationInitializer : FieldInitializerBase<PasswordConfirmationField>
    {
        public PasswordConfirmationInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(PasswordConfirmationField field)
        {

        }

        public override void PopulateLocalizedParameters(PasswordConfirmationField field)
        {

        }
    }
}