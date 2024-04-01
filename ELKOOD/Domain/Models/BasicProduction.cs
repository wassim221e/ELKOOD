using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BasicProduction
    {
        public string Id { get; set; }
        public required float Amount { get; set; }
        public required DateTime ProductionDate { get; set; }
        public required string MainBranchId { get; set; }
    }
}
