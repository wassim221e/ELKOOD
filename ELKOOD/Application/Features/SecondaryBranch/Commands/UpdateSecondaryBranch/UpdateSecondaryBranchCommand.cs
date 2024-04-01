using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.UpdateSecondaryBranch
{
    public class UpdateSecondaryBranchCommand : IRequest
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string BranchType { get; set; }

    }
}
