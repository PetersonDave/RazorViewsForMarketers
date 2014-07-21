using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class DateFieldInitializer : FieldInitializerBase<DateField>
    {
        public DateFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(DateField field)
        {
            var parameters = field.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    EDateFieldParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case EDateFieldParametersType.dateformat:
                            field.DateFormat = pair.Part2;
                            break;
                        case EDateFieldParametersType.startdate:
                            field.StartDate = pair.Part2;
                            break;
                    }
                }
            }
        }

        public override void PopulateLocalizedParameters(DateField field)
        {

        }
    }
}