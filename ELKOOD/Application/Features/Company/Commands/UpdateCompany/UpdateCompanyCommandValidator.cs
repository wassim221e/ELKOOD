using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommandValidator:AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(o => o.State.ToLower())
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .IsEnumName(typeof(Domain.Enums.StateOfCompany));
            RuleFor(o => o.Name.ToLower())
                .NotEmpty()
                .NotNull()
                .NotEqual("all")
                .MaximumLength(100);
            RuleFor(o => o.Location)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(o => o.Id)
                .NotEmpty()
                .NotNull();

        }
    }
}
