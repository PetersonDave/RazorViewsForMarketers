using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;
using Sitecore.Forms.Core.Data;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class DropListInitializer : FieldInitializerBase<DropListField>
    {
        public DropListInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(DropListField field)
        {
            var parameters = field.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
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

                                field.Items = new NameValueCollection {{"", ""}, dataSource};       // default to empty choice as setting may not always be in XML
                            }
                            break;
                        case EDropListParametersType.SelectedValue:
                            field.SelectedValue = pair.Part2;
                            break;
                        case EDropListParametersType.EmptyChoice:
                            bool noEmptyChoice = !string.IsNullOrEmpty(pair.Part2) && pair.Part2.ToLower().Equals("no");
                            if (noEmptyChoice)
                            {
                                field.Items.Remove("");
                            }
                            break;
                    }
                }
            }
        }

        public override void PopulateLocalizedParameters(DropListField field)
        {

        }
    }
}