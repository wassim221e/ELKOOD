using Application.Contracts;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Queries.GetAllCompany
{
    public class GetAllCompanyQueryHandler : IRequestHandler<GetAllCompanyQuery, List<GetCompanyViewModel>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompanyQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<GetCompanyViewModel>> Handle(GetAllCompanyQuery request, CancellationToken cancellationToken)
        {
            
            if (request.State is not null&& !Enum.GetNames(typeof(StateOfCompany)).Contains(request.State.ToLower()))
                throw new Exception("Please enter active or inactive or null");
            var AllCompanies= _companyRepository.GetAllAsync(false).Result;
            var Companies=AllCompanies.Where(o=>o.State==(request.State is not null?request.State.ToLower():o.State)).ToList();
            return Companies.Select(o=>new GetCompanyViewModel
            {
                Id=o.Id,
                Name=o.Name,
                Location=o.Location,
                State=o.State,
                DateOfEstablishment=o.DateOfEstablishment
            }).ToList();
        }
    }
}
