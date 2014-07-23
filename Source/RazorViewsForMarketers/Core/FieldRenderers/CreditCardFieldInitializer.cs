using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Core.FieldRenderers.EnumerationTypes;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;

namespace RazorViewsForMarketers.Core.FieldRenderers
{
    public class CreditCardFieldInitializer : FieldInitializerBase<CreditCardField>
    {
        public CreditCardFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(Field field, CreditCardField model)
        {
            IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(field.Value, true);
            foreach (var pair in p)
            {
                ECreditCardFieldParametersType fieldParametersType;
                bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                if (!isKnownType) continue;

                switch (fieldParametersType)
                {
                    case ECreditCardFieldParametersType.CardNumberHelp:
                        model.CardNumberHelp = pair.Part2;
                        break;
                    case ECreditCardFieldParametersType.CardNumberTitle:
                        model.CardNumberTitle = pair.Part2;
                        break;
                    case ECreditCardFieldParametersType.CardTypeHelp:
                        model.CardTypeHelp = pair.Part2;
                        break;
                    case ECreditCardFieldParametersType.CardTypes:
                        model.CardTypesQuery = pair.Part2;
                        break;
                    case ECreditCardFieldParametersType.CardTypeTitle:
                        model.CardTypeTitle = pair.Part2;
                        break;
                }
            }
        }

        public override void PopulateLocalizedParameters(Field field, CreditCardField model) { }
    }
}