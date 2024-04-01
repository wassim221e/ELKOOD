using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.AddProduction
{
    public class AddProductionCommandValidator:AbstractValidator<AddProductionCommand>
    {
        public AddProductionCommandValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100);
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(x => x.Type)
                .NotEmpty()
                .NotNull()
                .MaximumLength(200);
        }
    }
}
