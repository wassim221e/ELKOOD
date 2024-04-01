using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.DeleteCompany
{
    public class DeleteCompanyCommand:IRequest
    {

        public required string Id { get; set; }
    }
}
