using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.DeleteSecondaryBranch
{
    public class DeleteSecondaryBranchCommand : IRequest
    {
        public required string Id { get; set; }
    }
}
