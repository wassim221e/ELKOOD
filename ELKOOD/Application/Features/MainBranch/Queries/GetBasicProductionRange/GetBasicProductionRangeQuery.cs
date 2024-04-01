using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetBasicProductionRange
{
    public class GetBasicProductionRangeQuery:IRequest<float>
    {
        public required string MainBranchId { get; set; }
        public required DateTime Start { get; set; }
        public required DateTime End { get; set; }
    }
}
