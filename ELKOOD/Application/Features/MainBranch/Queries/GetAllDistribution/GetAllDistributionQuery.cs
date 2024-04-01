using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetAllDistribution
{
    public class GetAllDistributionQuery:IRequest<List<GetAllDistributionViewModel>>
    {
        public string? MainBranchId { get; set; }
    }
}
