using System;
using System.Collections.Generic;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Form.Core.Utility;

namespace RazorViewsForMarketers.Presenters.FieldRenderers
{
    public abstract class FieldInitializerBase<T> where T : WffmField
    {
        public abstract void PopulateParameters(T field);
        public abstract void PopulateLocalizedParameters(T field);
        public T Field { get; set; }

        protected FieldInitializerBase() { }

        protected FieldInitializerBase(Item fieldItem)
        {
            var fieldLink = fieldItem.Fields["Field Link"];
            if (fieldLink == null || !fieldLink.HasValue) throw new Exception(string.Format("Field {0} does not have a defined field type", fieldItem.Name));

            var fieldLinkItem = fieldItem.Database.Items[fieldLink.Value];
            if (fieldLinkItem == null) throw new Exception(string.Format("Field {0} does not have a defined field type item", fieldItem.Name));

            var theField = (T)Activator.CreateInstance(typeof (T));
            if (theField == null) return;

            PopulateCommonFields(theField, fieldItem);
            PopulateCommonParameters(theField);
            PopulateCommonLocalizedParameters(theField);

            PopulateParameters(theField);
            PopulateLocalizedParameters(theField);

            Field = theField;
        }

        private void PopulateCommonFields(WffmField field, Item fieldItem)
        {
            var isRequired = FieldTypeManager.GetField(fieldItem.Fields["Required"]) as Sitecore.Data.Fields.CheckboxField;
            if (isRequired == null) throw new Exception("isRequired is not a valid field");

            field.Item = fieldItem;
            field.IsRequired = isRequired.Checked;
            field.Title = fieldItem.Fields["Title"].Value;
        }

        private void PopulateCommonParameters(WffmField wffmField)
        {
            var parameters = wffmField.Item.Fields["Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    bool hasValue = !string.IsNullOrEmpty(pair.Part2);
                    if (!hasValue) continue;

                    EFieldParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case EFieldParametersType.cssclass:
                            wffmField.CssClass = pair.Part2;
                            break;
                        case EFieldParametersType.maxlength:
                            int maxLength;
                            bool isValidMaxLength = int.TryParse(pair.Part2, out maxLength);
                            wffmField.MaximumLength = isValidMaxLength ? maxLength : 0;
                            break;
                        case EFieldParametersType.minlength:
                            int minLength;
                            bool isValidMinLength = int.TryParse(pair.Part2, out minLength);
                            wffmField.MaximumLength = isValidMinLength ? minLength : 0;
                            break;
                        case EFieldParametersType.predefinedvalidator:
                            ID validatorItemId;
                            bool isValidId = ID.TryParse(pair.Part2, out validatorItemId);
                            if (!isValidId) continue;

                            var validatorItem = Sitecore.Context.Database.Items[validatorItemId];
                            if (validatorItem == null) continue;

                            bool hasValidationExpression = validatorItem.Fields["Value"] != null && validatorItem.Fields["Value"].HasValue;
                            if (!hasValidationExpression) continue;

                            wffmField.PredefinedValidatorPattern = validatorItem.Fields["Value"].Value;
                            break;
                        case EFieldParametersType.regexpattern:
                            wffmField.RegExPattern = pair.Part2;
                            break;
                    }
                }
            }
        }

        private void PopulateCommonLocalizedParameters(WffmField wffmField)
        {
            var parameters = wffmField.Item.Fields["Localized Parameters"];
            if (parameters.HasValue)
            {
                IEnumerable<Pair<string, string>> p = ParametersUtil.XmlToPairArray(parameters.Value, true);
                foreach (var pair in p)
                {
                    bool hasValue = !string.IsNullOrEmpty(pair.Part2);
                    if (!hasValue) continue;

                    EFieldLocalizedParametersType fieldParametersType;
                    bool isKnownType = Enum.TryParse(pair.Part1, true, out fieldParametersType);
                    if (!isKnownType) continue;

                    switch (fieldParametersType)
                    {
                        case EFieldLocalizedParametersType.information:
                            wffmField.Information = pair.Part2;
                            break;
                        case EFieldLocalizedParametersType.text:
                            wffmField.Text = pair.Part2;
                            break;
                    }
                }
            }
        }
    }
}