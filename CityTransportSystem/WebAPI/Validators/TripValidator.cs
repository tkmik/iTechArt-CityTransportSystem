using FluentValidation;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public class TripValidator : AbstractValidator<TripViewModel>
    {
        public TripValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.TripName).MaximumLength(100);
        }
    }
}
