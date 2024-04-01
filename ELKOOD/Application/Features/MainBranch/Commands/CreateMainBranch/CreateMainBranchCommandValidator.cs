using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.CreateMainBranch
{
    public class CreateMainBranchCommandValidator : AbstractValidator<CreateMainBranchCommand>
    {
        public CreateMainBranchCommandValidator()
        {
            RuleFor(x => x.Name.ToLower())
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .NotEqual("all");
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100)
                .NotEqual("all");
            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
        }
    }
}
