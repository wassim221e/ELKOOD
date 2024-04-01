using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.CreateCompany
{
    public class CreateCompanyCommand:IRequest<Domain.Models.Company>
    {
        public required string Name { get; set; }
        public required string Location { get; set; }
        public required DateTime DateOfEstablishment { get; set; }
        public required string State { get; set; }
    }
}
