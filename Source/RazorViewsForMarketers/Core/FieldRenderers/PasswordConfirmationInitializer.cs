using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class PasswordConfirmationInitializer : FieldInitializerBase<PasswordConfirmationField>
    {
        public PasswordConfirmationInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, PasswordConfirmationField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, PasswordConfirmationField model)
        {

        }
    }
}