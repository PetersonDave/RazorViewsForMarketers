using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using RazorViewsForMarketers.Core;
using Sitecore.Data;

namespace RazorViewsForMarketers.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class RuntimeValidationAttribute : ValidationAttribute
    {
        public string ValidatorsProperty { get; private set; }
        public string ValidationProperty { get; private set; }
        public string RegularExpressionValidationMessage { get; private set; }

        public RuntimeValidationAttribute(string validationProperty = "Id", string validatorsProperty = "Validators", string errorMessage = "The field is invalid.")
            : base(errorMessage)
        {
            ValidatorsProperty = validatorsProperty;
            ValidationProperty = validationProperty;
            RegularExpressionValidationMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo propertyId = validationContext.ObjectType.GetProperty(ValidationProperty);

            if (propertyId == null || propertyId.PropertyType != typeof(Guid))
            {
                throw new ArgumentException(ValidationProperty + " is not a valid property for " + validationContext.ObjectType.Name, ValidationProperty);
            }

            var fieldId = (Guid)propertyId.GetValue(validationContext.ObjectInstance, null);
            ID id;
            ID.TryParse(fieldId, out id);

            var fieldItem = Sitecore.Context.Database.Items[id];
            var validators = WffmFieldFactory.GetValidators(fieldItem);
            if (validators == null) return ValidationResult.Success; 

            foreach (var validator in validators)
            {
                bool isValid = validator.Validate(value as string);
                return isValid ? ValidationResult.Success : new ValidationResult(validator.Validator.ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}