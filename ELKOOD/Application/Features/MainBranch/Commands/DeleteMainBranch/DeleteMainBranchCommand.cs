using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.DeleteMainBranch
{
    public class DeleteMainBranchCommand : IRequest
    {
        public required string Id { get; set; }
    }
}
