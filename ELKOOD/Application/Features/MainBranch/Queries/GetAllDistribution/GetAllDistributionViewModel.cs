using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetAllDistribution
{
    public class GetAllDistributionViewModel
    {
        public string Id { get; set; }
        public required DateTime DateOperation { get; set; }
        public required float Amount { get; set; }
        public required string MainBranchId { get; set; }
        public required string MainBranchName { get; set; }
        public required string SecondaryBranchId { get; set; }
        public required string SecondaryBranchName { get; set; }
    }
}
