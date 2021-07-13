using FluentValidation;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public class StopValidator : AbstractValidator<StopViewModel>
    {
        public StopValidator()
        {
            RuleFor(s => s.Id).NotNull();
            RuleFor(s => s.Name).MaximumLength(100).NotNull();
            RuleFor(s => s.Coordinate).MaximumLength(100).NotNull();
            RuleFor(s => s.Address).MaximumLength(25).NotNull();
        }
    }
}
