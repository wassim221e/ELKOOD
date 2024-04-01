using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.AddDistribution
{
    public class AddDistributionQueryValidator:AbstractValidator<AddDistributionQuery>
    {
        public AddDistributionQueryValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0);
            RuleFor(x => x.MainBranchName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.SecondaryBranchName)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.DateOperation)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
