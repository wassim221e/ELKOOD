using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.CreateMainBranch
{
    public class CreateMainBranchCommand : IRequest<Domain.Models.MainBranch>
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required string CompanyName { get; set; }
    }
}
