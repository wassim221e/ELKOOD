using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.AddBasicProduction
{
    public class AddBasicProductionCommandValidator:AbstractValidator<AddBasicProductionCommand>
    {
        public AddBasicProductionCommandValidator()
        {
            RuleFor(x => x.Amount)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0);
            RuleFor(x => x.MainBranchName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.CompanyName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.DateOperation)
                .NotNull()
                .NotEmpty();
        }
    }
}
