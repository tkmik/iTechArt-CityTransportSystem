using FluentValidation;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public class TripValidationValidator : AbstractValidator<TripValidationViewModel>
    {
        public TripValidationValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.ValidationTime).NotNull();
        }
    }
}
