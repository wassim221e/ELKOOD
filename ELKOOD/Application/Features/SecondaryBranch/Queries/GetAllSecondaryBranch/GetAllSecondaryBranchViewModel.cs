using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Queries.GetAllSecondaryBranch
{
    public class GetAllSecondaryBranchViewModel
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string MainBranchId { get; set; }
        public required string MainBranchName { get; set; }
    }
}
