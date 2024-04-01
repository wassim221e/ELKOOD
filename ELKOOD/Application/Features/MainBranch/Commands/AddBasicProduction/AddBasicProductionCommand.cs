using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.AddBasicProduction
{
    public class AddBasicProductionCommand:IRequest
    {
        public required float Amount { get; set; }
        public required string CompanyName { get; set; }
        public required string MainBranchName { get; set; }
        public required DateTime DateOperation { get; set; }
        
    }
}
