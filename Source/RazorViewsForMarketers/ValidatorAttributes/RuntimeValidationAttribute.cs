using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using RazorViewsForMarketers.Presenters;
using RazorViewsForMarketers.Validators;
using Sitecore.Reflection;
using Validator = RazorViewsForMarketers.Models.Validators.Validator;

namespace RazorViewsForMarketers.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
    public class RuntimeValidationAttribute : ValidationAttribute
    {
        public string ValidatorsProperty { get; private set; }
        public string ValidationProperty { get; private set; }
        public string RegularExpressionValidationMessage { get; private set; }

        public RuntimeValidationAttribute(string validationProperty = "ValidatorIds", string validatorsProperty = "Validators", string errorMessage = "The field is invalid.")
            : base(errorMessage)
        {
            ValidatorsProperty = validatorsProperty;
            ValidationProperty = validationProperty;
            RegularExpressionValidationMessage = errorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo propertyRegularExpression = validationContext.ObjectType.GetProperty(ValidationProperty);

            if (propertyRegularExpression == null || propertyRegularExpression.PropertyType != typeof(string))
            {
                throw new ArgumentException(ValidationProperty + " is not a valid property for " + validationContext.ObjectType.Name, ValidationProperty);
            }

            var validators = (string)propertyRegularExpression.GetValue(validationContext.ObjectInstance, null);
            var validatorIds = validators.Split('|');
            foreach (var validatorId in validatorIds)
            {
                var validatorModel = WffmFieldFactory.GetValidator(validatorId);
                if (validatorModel == null) continue;

                var validator = GetValidator(validatorModel);
                if (validator != null)
                {
                    bool isValid = validator.Validate(value as string);
                    return isValid ? ValidationResult.Success : new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }

        private IValidator GetValidator(Validator validatorModel)
        {
            var type = ReflectionUtil.GetTypeInfo(validatorModel.Assembly, validatorModel.Class);
            bool isValidType = type != null && typeof (IValidator).IsAssignableFrom(type);
            if (isValidType)
            {
                return Activator.CreateInstance(type, validatorModel.ValidationExpression) as IValidator;
            }

            return null;
        }
    }
}