using System.Text.RegularExpressions;
using RazorViewsForMarketers.Models.Validators;

namespace RazorViewsForMarketers.Core.Validators
{
    public class GenericValidator : IValidator
    {
        public GenericValidatorModel Validator { get; set; }

        public GenericValidator(GenericValidatorModel model)
        {
            Validator = model;
        }

        public bool Validate(string value)
        {
            if (string.IsNullOrEmpty(value)) return true;

            bool canValidate = Validator != null && !string.IsNullOrEmpty(Validator.ValidationExpression);
            if (!canValidate) return true;

            var regEx = new Regex(Validator.ValidationExpression);
            return regEx.IsMatch(value);
        }
    }
}