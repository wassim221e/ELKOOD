using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Company
    {
        public string Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(200)]
        public required string Location { get; set; }
        public required DateTime DateOfEstablishment { get; set; }
        [MaxLength(50)]
        public required string State { get; set; }
        public required ICollection<MainBranch> MainBranches { get; set; }
        public required ICollection<Product> Products { get; set; }
    }
}
