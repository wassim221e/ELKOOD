using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommand:IRequest<Domain.Models.Company>
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public required string State { get; set; }
        public required string Location { get; set; }

    }
}
