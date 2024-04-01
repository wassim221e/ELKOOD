using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.UpdateMainBranch
{
    public class UpdateMainBranchCommand : IRequest
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string BranchType { get; set; }
        public string? mainBranchName { get; set; } = null;
    }
}
