using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Queries.GetSecondaryBranchDetails
{
    public class GetSecondaryBranchDetailsQuery:IRequest<GetSecondaryBranchDetailsViewModel>
    {
        public required string Id { get; set; }
    }
}
