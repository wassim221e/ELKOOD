using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Queries.GetAllCompany
{
    public class GetAllCompanyQuery:IRequest<List<GetCompanyViewModel>>
    {
        public string? State { get; set; }
    }
}
