using FluentValidation;
using WebAPI.ViewModels;

namespace WebAPI.Validators
{
    public class TransportValidator : AbstractValidator<TransportViewModel>
    {
        public TransportValidator()
        {
            RuleFor(t => t.Id).NotNull();
            RuleFor(t => t.Vin).Length(17).NotNull();
            RuleFor(t => t.PlateNumber).MaximumLength(8).NotNull();
            RuleFor(t => t.ProductionYear).NotNull();
            RuleFor(t => t.InspectionYear).NotNull();
            RuleFor(t => t.FuelType).MaximumLength(100).NotNull();
            RuleFor(t => t.FuelConsumptionPer100km).NotNull();
            RuleFor(t => t.StatusDecommissioned).NotNull();
        }
    }
}
