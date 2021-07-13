using FluentValidation;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public class TicketValidator : AbstractValidator<TicketViewModel>
    {
        public TicketValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.SerialNumber).NotNull();
            RuleFor(t => t.Cost).NotNull();
        }
    }
}
