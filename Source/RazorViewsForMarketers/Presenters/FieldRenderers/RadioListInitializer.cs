using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;
using Sitecore.Forms.Core.Data;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class RadioListInitializer : FieldInitializerBase<RadioButtonListField>
    {
        public RadioListInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(RadioButtonListField field)
        {
            var parameters = field.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    ERadioButtonListParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case ERadioButtonListParametersType.Items:
                            bool isQueryValid = !string.IsNullOrEmpty(pair.Part2);
                            if (isQueryValid)
                            {
                                var querySettings = QuerySettings.ParseRange(pair.Part2);
                                var dataSource = QueryManager.Select(querySettings);

                                // TODO: continue processing
                            }
                            break;
                        case ERadioButtonListParametersType.SelectedValue:
                            field.SelectedValue = pair.Part2;
                            break;
                        case ERadioButtonListParametersType.Columns:
                            field.Columns = pair.Part2;
                            break;
                        case ERadioButtonListParametersType.Direction:
                            field.Direction = pair.Part2;
                            break;
                    }
                }
            }
        }

        public override void PopulateLocalizedParameters(RadioButtonListField field)
        {

        }
    }
}