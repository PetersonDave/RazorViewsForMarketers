using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using RazorViewsForMarketers.Models.Fields;
using RazorViewsForMarketers.Providers;

namespace RazorViewsForMarketers.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class RuntimeRegularExpressionAttribute : ValidationAttribute, IClientValidatable
    {
        public string RegularExpressionProperty { get; private set; }
        public string RegularExpressionValidationMessage { get; private set; }

        public RuntimeRegularExpressionAttribute(string regularExpressionProperty = "RegularExpression", string errorMessage = "The field is invalid.") : base(errorMessage)
        {
            RegularExpressionProperty = regularExpressionProperty;
            RegularExpressionValidationMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || (value as string) == null) return ValidationResult.Success;

            PropertyInfo propertyRegularExpression = validationContext.ObjectType.GetProperty(RegularExpressionProperty);

            if (propertyRegularExpression == null || propertyRegularExpression.PropertyType != typeof(string))
            {
                throw new ArgumentException(RegularExpressionProperty + " is not a valid property for " + validationContext.ObjectType.Name, RegularExpressionProperty);
            }

            var regularExpression = propertyRegularExpression.GetValue(validationContext.ObjectInstance, null);
            bool canValidate = !string.IsNullOrEmpty(value as string) && !string.IsNullOrEmpty(regularExpression as string);
            if (canValidate)
            {
                var match = Regex.Match(value as string, regularExpression as string);
                if (!match.Success)
                {
                    var errorMessage = string.IsNullOrEmpty(ErrorMessage) ? FormatErrorMessage(validationContext.DisplayName) : ErrorMessage;
                    return new ValidationResult(errorMessage);    
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            object container;
            if (metadata.AdditionalValues.TryGetValue(CustomModelMetadataProvider.DynamicContainerKey, out container) && container is WffmField)
            {
                var regularExpression = container.GetType().GetProperty(RegularExpressionProperty).GetValue(container, null) as string;
                if (string.IsNullOrEmpty(regularExpression))
                {
                    regularExpression = "[^]*";   // if nothing provided, accept everything (including newlines)
                }

                yield return new ModelClientValidationRegexRule(RegularExpressionValidationMessage, regularExpression);
            }
            else
            {
                //we have to return a ModelCLientValidationRule where
                //ValidationType is not empty or else we get an exception
                //since we don't add validation rules clientside for 'notrequired'
                //no validation occurs and this works, though it's a bit of a hack
                yield return new ModelClientValidationRegexRule(string.Empty, string.Empty);
            }
        }
    }
}