using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetMainBranchDetails
{
    public class GetMainBranchDetailsQuery:IRequest<GetMainBranchQueryViewModel>
    {
        public required string Id { get; set; }
    }
}
