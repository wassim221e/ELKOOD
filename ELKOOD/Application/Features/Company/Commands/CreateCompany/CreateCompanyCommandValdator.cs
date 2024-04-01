using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandValdator:AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValdator() 
        {
            RuleFor(x => x.Name.ToLower())
                .NotEmpty()
                .NotNull()
                .NotEqual("all")
                .MaximumLength(100);
            RuleFor(x => x.Location)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
            RuleFor(x => x.State.ToLower())
                .NotNull()
                .NotEmpty()
                .MaximumLength(50)
                .IsEnumName(typeof(Domain.Enums.StateOfCompany));
            RuleFor(x => x.DateOfEstablishment)
                .NotEmpty()
                .NotNull();
        }
    }
}
