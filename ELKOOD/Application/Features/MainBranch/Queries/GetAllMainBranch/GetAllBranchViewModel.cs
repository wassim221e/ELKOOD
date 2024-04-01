using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetAllMainBranch
{
    public class GetAllBranchViewModel
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string CompanyId { get; set; }
        public required string CompanyName { get; set; }
    }
}
