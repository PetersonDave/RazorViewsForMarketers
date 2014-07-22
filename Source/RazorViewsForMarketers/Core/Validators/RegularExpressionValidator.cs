using System.Text.RegularExpressions;
using RazorViewsForMarketers.Models.Validators;

namespace RazorViewsForMarketers.Core.Validators
{
    public class RegularExpressionValidator : IValidator<GenericValidator>
    {
        private readonly string _regularExpression;
        public Validator Validator { get; set; }

        public RegularExpressionValidator(string regularExpression)
        {
            _regularExpression = regularExpression;
        }

        public bool Validate(string value)
        {
            var regEx = new Regex(_regularExpression);
            return regEx.IsMatch(value);
        }
    }
}