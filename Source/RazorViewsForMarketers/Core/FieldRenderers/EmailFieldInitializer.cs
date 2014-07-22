using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class EmailFieldInitializer : FieldInitializerBase<EmailField>
    {
        public EmailFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(EmailField field)
        {

        }

        public override void PopulateLocalizedParameters(EmailField field)
        {

        }
    }
}