using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetAllMainBranch
{
    public class GetAllMainBranchQuery:IRequest<List<GetAllBranchViewModel>>
    {
        public string?CompanyName { get; set; }
    }
}
