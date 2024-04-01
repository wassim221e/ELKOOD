using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Queries.GetCompanyDetails
{
    public class GetCompanyDetailsQueryHandler : IRequestHandler<GetCompanyDetailsQuery, Domain.Models.Company>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyDetailsQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Domain.Models.Company> Handle(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
        {
            var Company = await _companyRepository.GetById(request.Id,true);
            return Company;
        }
    }
}
