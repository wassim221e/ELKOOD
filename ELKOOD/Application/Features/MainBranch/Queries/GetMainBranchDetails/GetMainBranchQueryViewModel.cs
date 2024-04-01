using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetMainBranchDetails
{
    public class GetMainBranchQueryViewModel
    {
        public string Id { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(200)]
        public required string Location { get; set; }
        public required string CompanyId { get; set; }
        public required string CompanyName { get; set; }
        public required ICollection<Domain.Models.SecondaryBranch> SecondaryBranches { get; set; }
        public required ICollection<BasicProduction> BasicProductions { get; set; }
        public required ICollection<Distribution> Distributions { get; set; }
    }
}
