using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Core.ValidatorRenderers.EnumerationTypes;
using RazorViewsForMarketers.Models.Validators;
using RazorViewsForMarketers.Presenters;
using Sitecore.Collections;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;
using Sitecore.Forms.Core.Crm;
using Sitecore.Shell.Feeds.Sections;

namespace RazorViewsForMarketers.Core.ValidatorRenderers
{
    public abstract class ValidatorInitializerBase<T> where T : Validator
    {
        public abstract void PopulateValidatorFields(Item validatorItem, T wffmValidator);
        public abstract void PopulateParameters(T wffmValidator);
        public abstract void PopulateLocalizedParameters(T wffmValidator);
        public T Validator { get; set; }

        protected ValidatorInitializerBase() { }

        protected ValidatorInitializerBase(Item validatorItem)
        {
            if (validatorItem == null) throw new Exception(string.Format("validator is null"));

            var theValidator = (T)Activator.CreateInstance(typeof (T));
            if (theValidator == null) return;

            PopulateCommonValidatorFields(validatorItem, theValidator);
            PopulateCommonParameters(theValidator);
            PopulateCommonLocalizedParameters(theValidator);

            PopulateValidatorFields(validatorItem, theValidator);
            PopulateParameters(theValidator);
            PopulateLocalizedParameters(theValidator);

            Validator = theValidator;
        }

        private void PopulateCommonValidatorFields(Item validatorItem, Validator wffmValidator)
        {
            CheckboxField enableClientScript = validatorItem.Fields["Enable Client Script"];

            wffmValidator.AnalyticsFieldEvent = validatorItem.Fields["Field Event"].Value;
            wffmValidator.Assembly = validatorItem.Fields["Assembly"].Value;
            wffmValidator.Class = validatorItem.Fields["Class"].Value;
            wffmValidator.EnableClientScript = enableClientScript.Checked;
            wffmValidator.ErrorMessage = validatorItem.Fields["Error Message"].Value;
            wffmValidator.ErrorText = validatorItem.Fields["Text"].Value;

            wffmValidator.ValidatorDisplay = validatorItem.Fields["Validator Display"].Value;
            wffmValidator.Item = validatorItem;

            if (validatorItem.Fields["Validation Expression"] != null)
            {
                wffmValidator.ValidationExpression = validatorItem.Fields["Validation Expression"].Value;    
            }
        }

        private void PopulateCommonParameters(Validator wffmValidator)
        {
            var parameters = wffmValidator.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    bool hasValue = !string.IsNullOrEmpty(pair.Part2);
                    if (!hasValue) continue;

                    EValidatorParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case EValidatorParametersType.text:
                            wffmValidator.Text = pair.Part2;
                            break;
                        case EValidatorParametersType.clientValidationFunction:
                            wffmValidator.ClientValidationFunction = pair.Part2;
                            break;
                    }
                }
            }
        }

        private void PopulateCommonLocalizedParameters(Validator wffmField)
        {
            var parameters = wffmField.Item.Fields["Localized Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    bool hasValue = !string.IsNullOrEmpty(pair.Part2);
                    if (!hasValue) continue;

                    // currently no common localized parameters
                }
            }
        }
    }
}