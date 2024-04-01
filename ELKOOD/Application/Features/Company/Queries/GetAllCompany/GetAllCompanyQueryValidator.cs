using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Queries.GetAllCompany
{
    public class GetAllCompanyQueryValidator:AbstractValidator<GetAllCompanyQuery>
    {
        public GetAllCompanyQueryValidator()
        {
            RuleFor(o => o.State.ToLower())
                 .MaximumLength(50);
        }
    }
}
