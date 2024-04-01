using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.CreateSecondaryBranch
{
    public class CreateSecondaryBranchCommandValidator : AbstractValidator<CreateSecondaryBranchCommand>
    {
        public CreateSecondaryBranchCommandValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100);
            RuleFor(x => x.MainBranchName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
            RuleFor(x => x.CompanyName)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100);

        }
    }
}
