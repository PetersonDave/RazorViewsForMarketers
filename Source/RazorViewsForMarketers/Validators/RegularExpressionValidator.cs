using System.Text.RegularExpressions;

namespace RazorViewsForMarketers.Validators
{
    public class RegularExpressionValidator : IValidator
    {
        private readonly string _regularExpression;

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