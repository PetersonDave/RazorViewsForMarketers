using RazorViewsForMarketers.Models.Validators;

namespace RazorViewsForMarketers.Core.Validators
{
    public interface IValidator
    {
        GenericValidatorModel Validator { get; set; }
        bool Validate(string value);
    }
}