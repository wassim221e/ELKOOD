using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetBasicProductionRange
{
    public class GetBasicProductionRangeQueryValidator:AbstractValidator<GetBasicProductionRangeQuery>
    {
        public GetBasicProductionRangeQueryValidator()
        {
            RuleFor(x => x.Start)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.End)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.MainBranchId)
                .NotNull()
                .NotEmpty();
        }
    }
}
