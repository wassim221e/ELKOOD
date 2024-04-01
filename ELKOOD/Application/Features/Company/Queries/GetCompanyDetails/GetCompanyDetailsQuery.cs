using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Queries.GetCompanyDetails
{
    public class GetCompanyDetailsQuery:IRequest<Domain.Models.Company>
    {
        public required string Id { get; set; }
    }
}
