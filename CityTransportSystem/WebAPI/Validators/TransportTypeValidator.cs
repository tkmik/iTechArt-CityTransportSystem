using FluentValidation;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public class TransportTypeValidator : AbstractValidator<TransportTypeViewModel>
    {
        public TransportTypeValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.TransportTypeName).MaximumLength(100).NotNull();
        }
    }
}
