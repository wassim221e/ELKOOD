using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.CreateSecondaryBranch
{
    public class CreateSecondaryBranchCommand : IRequest<Domain.Models.SecondaryBranch>
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string CompanyName { get; set; }
        public required string MainBranchName { get; set; }
        
    }
}
