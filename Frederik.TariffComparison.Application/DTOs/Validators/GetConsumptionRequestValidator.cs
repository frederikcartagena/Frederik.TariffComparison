using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frederik.TariffComparison.Application.DTOs.Validators
{
    public  class GetConsumptionRequestValidator : AbstractValidator<GetConsumptionRequest>
    {
        public GetConsumptionRequestValidator()
        {
            RuleFor(x => x.ConsumptionKwh)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0).WithMessage("{PropertyName} must be at least 1.")
                .LessThan(100000).WithMessage("{PropertyName} must be less than {ComparisonValue}.");
        }
    }
}
