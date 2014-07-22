using RazorViewsForMarketers.Models.Validators;

namespace RazorViewsForMarketers.Core.Validators
{
    public interface IValidator<T> where T : Validator
    {
        bool Validate(string value);
    }
}