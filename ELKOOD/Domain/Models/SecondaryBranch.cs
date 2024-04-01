using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class SecondaryBranch
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string MainBranchId { get; set; }
    }
}
