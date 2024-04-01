using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.UpdateMainBranch
{
    public class UpdateMainBranchCommandValidator : AbstractValidator<UpdateMainBranchCommand>
    {
        public UpdateMainBranchCommandValidator()
        {
            RuleFor(x => x.Name.ToLower())
               .NotEmpty()
               .NotNull()
               .MaximumLength(100);
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
