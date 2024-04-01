using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.UpdateSecondaryBranch
{
    public class UpdateSecondaryBranchCommandValidator : AbstractValidator<UpdateSecondaryBranchCommand>
    {
        public UpdateSecondaryBranchCommandValidator()
        {
            RuleFor(x => x.Name.ToLower())
              .NotEmpty()
              .NotNull()
              .MaximumLength(100)
              .NotEqual("all");
            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
            RuleFor(x => x.BranchType)
                .NotEmpty()
                .NotNull()
                .IsEnumName(typeof(Domain.Enums.BranchType));
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
