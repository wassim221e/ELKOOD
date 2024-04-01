using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Queries.GetAllSecondaryBranch
{
    public class GetAllSecondaryBranchQuery:IRequest<List<GetAllSecondaryBranchViewModel>>
    {
       public string? MainBranchId { get; set; }
    }
}
