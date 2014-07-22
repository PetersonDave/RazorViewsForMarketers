using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Models.Fields;
using RazorViewsForMarketers.Presenters;
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

                                // TODO: continue processing
                            }
                            break;
                        case EDropListParametersType.SelectedValue:
                            field.SelectedValue = pair.Part2;
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