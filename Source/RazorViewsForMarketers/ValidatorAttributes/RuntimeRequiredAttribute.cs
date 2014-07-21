using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Web.Mvc;
using RazorViewsForMarketers.Models.Fields;
using RazorViewsForMarketers.Providers;

namespace RazorViewsForMarketers.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class RuntimeRequiredAttribute : ValidationAttribute, IClientValidatable
    {
        public string BooleanSwitch { get; private set; }
        public bool AllowEmptyStrings { get; private set; }

        public RuntimeRequiredAttribute(string booleanSwitch = "IsRequired", bool allowEmpytStrings = false)
            : base("This field is required.")
        {
            BooleanSwitch = booleanSwitch;
            AllowEmptyStrings = allowEmpytStrings;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo property = validationContext.ObjectType.GetProperty(BooleanSwitch);

            if (property == null || property.PropertyType != typeof(bool))
            {
                throw new ArgumentException(BooleanSwitch + " is not a valid boolean property for " + validationContext.ObjectType.Name, BooleanSwitch);
            }

            if ((bool)property.GetValue(validationContext.ObjectInstance, null) &&
                (value == null || (!AllowEmptyStrings && value is string && String.IsNullOrWhiteSpace(value as string))))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            bool isRequired = false;
            object container;
            if (metadata.AdditionalValues.TryGetValue(CustomModelMetadataProvider.DynamicContainerKey, out container) && container is WffmField)
            {
                isRequired = (bool)container.GetType().GetProperty(BooleanSwitch).GetValue(container, null);
            }

            if (isRequired)
            {
                yield return new ModelClientValidationRequiredRule(FormatErrorMessage(metadata.DisplayName ?? metadata.PropertyName));
            }
            else
            //we have to return a ModelCLientValidationRule where
            //ValidationType is not empty or else we get an exception
            //since we don't add validation rules clientside for 'notrequired'
            //no validation occurs and this works, though it's a bit of a hack
            {
                yield return new ModelClientValidationRule { ValidationType = "notrequired", ErrorMessage = "" };
            }
        }
    }
}