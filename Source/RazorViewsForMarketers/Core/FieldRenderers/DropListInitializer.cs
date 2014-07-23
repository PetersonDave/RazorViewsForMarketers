using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;
using Sitecore.Forms.Core.Data;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class DropListInitializer : FieldInitializerBase<DropListField>
    {
        public DropListInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, DropListField model)
        {
            IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(field.Value, true);
            foreach (var pair in p)
            {
                EDropListParametersType fieldParametersType;
                bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                if (!isKnownType) continue;

                switch (fieldParametersType)
                {
                    case EDropListParametersType.Items:
                        bool isQueryValid = !string.IsNullOrEmpty(pair.Part2);
                        if (isQueryValid)
                        {
                            var querySettings = QuerySettings.ParseRange(pair.Part2);
                            var dataSource = QueryManager.Select(querySettings);

                            model.Items = new NameValueCollection { { "", "" }, dataSource };       // default to empty choice as setting may not always be in XML
                        }
                        break;
                    case EDropListParametersType.SelectedValue:
                        model.SelectedValue = pair.Part2;
                        break;
                    case EDropListParametersType.EmptyChoice:
                        bool noEmptyChoice = !string.IsNullOrEmpty(pair.Part2) && pair.Part2.ToLower().Equals("no");
                        if (noEmptyChoice)
                        {
                            model.Items.Remove("");
                        }
                        break;
                }
            }
        }

        public override void PopulateLocalizedParameters(Field field, DropListField model)
        {

        }
    }
}