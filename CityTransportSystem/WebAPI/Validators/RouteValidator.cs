using FluentValidation;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public class RouteValidator : AbstractValidator<RouteViewModel>
    {
        public RouteValidator()
        {
            RuleFor(r => r.Id).NotNull();
            RuleFor(r => r.RouteName).MaximumLength(100).NotNull();
            RuleFor(r => r.Season).MaximumLength(100).NotNull();
        }
    }
}
