using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetAllMainBranch
{
    public class GetAllMainBranchQueryValidator:AbstractValidator<GetAllMainBranchQuery>
    {
        public GetAllMainBranchQueryValidator()
        {
            RuleFor(x => x.CompanyName)
                .MaximumLength(100);
        }
    }
}
