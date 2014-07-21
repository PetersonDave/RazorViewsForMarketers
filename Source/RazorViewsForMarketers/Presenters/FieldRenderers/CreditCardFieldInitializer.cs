using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public class CreditCardFieldInitializer : FieldInitializerBase<CreditCardField>
    {
        public CreditCardFieldInitializer(Item fieldItem) : base(fieldItem) { }

        public override void PopulateParameters(CreditCardField field)
        {
            var parameters = field.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    ECreditCardFieldParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case ECreditCardFieldParametersType.CardNumberHelp:
                            field.CardNumberHelp = pair.Part2;
                            break;
                        case ECreditCardFieldParametersType.CardNumberTitle:
                            field.CardNumberTitle = pair.Part2;
                            break;
                        case ECreditCardFieldParametersType.CardTypeHelp:
                            field.CardTypeHelp = pair.Part2;
                            break;
                        case ECreditCardFieldParametersType.CardTypes:
                            field.CardTypesQuery = pair.Part2;
                            break;
                        case ECreditCardFieldParametersType.CardTypeTitle:
                            field.CardTypeTitle = pair.Part2;
                            break;
                    }
                }
            }
        }

        public override void PopulateLocalizedParameters(CreditCardField field) { }
    }
}