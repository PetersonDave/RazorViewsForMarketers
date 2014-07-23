using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Presenters;
using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;
using CheckboxField = RazorViewsForMarketers.Models.Fields.CheckboxField;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class CheckBoxListInitializer : FieldInitializerBase<CheckboxField>
    {
        public CheckBoxListInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, CheckboxField model)
        {
            IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(field.Value, true);
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
                        model.Checked = isChecked;
                        break;
                }
            }
        }

        public override void PopulateLocalizedParameters(Field field, CheckboxField model)
        {

        }
    }
}