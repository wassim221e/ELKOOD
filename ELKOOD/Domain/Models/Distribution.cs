using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Distribution
    {
        public string Id { get; set; }
        public required DateTime DateOperation { get; set; }
        public required float Amount { get; set; }
        public required string MainBranchId { get; set; }
        public required string SecondaryBranchId { get; set; }
    }
}
