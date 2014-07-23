using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class EmailFieldInitializer : FieldInitializerBase<EmailField>
    {
        public EmailFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, EmailField model)
        {

        }

        public override void PopulateLocalizedParameters(Field field, EmailField model)
        {

        }
    }
}