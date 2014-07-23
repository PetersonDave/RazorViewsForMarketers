using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class PasswordFieldInitializer : FieldInitializerBase<PasswordField>
    {
        public PasswordFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, PasswordField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, PasswordField model)
        {

        }
    }
}