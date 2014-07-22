using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class PasswordFieldInitializer : FieldInitializerBase<PasswordField>
    {
        public PasswordFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(PasswordField field)
        {

        }

        public override void PopulateLocalizedParameters(PasswordField field)
        {

        }
    }
}