using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Presenters;
using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;
using DateField = RazorViewsForMarketers.Models.Fields.DateField;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class DateFieldInitializer : FieldInitializerBase<DateField>
    {
        public DateFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, DateField model)
        {
            IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(field.Value, true);
            foreach (var pair in p)
            {
                EDateFieldParametersType fieldParametersType;
                bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                if (!isKnownType) continue;

                switch (fieldParametersType)
                {
                    case EDateFieldParametersType.dateformat:
                        model.DateFormat = pair.Part2;
                        break;
                    case EDateFieldParametersType.startdate:
                        model.StartDate = pair.Part2;
                        break;
                }
            }
        }

        public override void PopulateLocalizedParameters(Field field, DateField model)
        {

        }
    }
}