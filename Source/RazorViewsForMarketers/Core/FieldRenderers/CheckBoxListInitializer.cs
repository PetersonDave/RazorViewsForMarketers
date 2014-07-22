using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Models.Fields;
using RazorViewsForMarketers.Presenters;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class CheckBoxListInitializer : FieldInitializerBase<CheckboxField>
    {
        public CheckBoxListInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(CheckboxField field)
        {
            var parameters = field.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    ECheckboxFieldParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case ECheckboxFieldParametersType.Checked:
                            bool isChecked;
                            bool.TryParse(pair.Part2, out isChecked);
                            field.Checked = isChecked;
                            break;
                    }
                }
            }
        }

        public override void PopulateLocalizedParameters(CheckboxField field)
        {

        }
    }
}