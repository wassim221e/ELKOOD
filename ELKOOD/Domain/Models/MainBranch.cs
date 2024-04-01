using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MainBranch
    {
        public string Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(200)]
        public required string Location { get; set; }
        public required string CompanyId { get; set; }
        public required ICollection<SecondaryBranch> SecondaryBranches { get; set; }
        public required ICollection<BasicProduction> BasicProductions { get; set; }
        public required ICollection<Distribution> Distributions { get; set; }
    }
}
