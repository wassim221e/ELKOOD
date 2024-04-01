using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetMainBranchDetails
{
    public class GetMainBranchQueryHandler : IRequestHandler<GetMainBranchDetailsQuery, GetMainBranchQueryViewModel>
    {
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ICompanyRepository _companyRepository;

        public GetMainBranchQueryHandler(IMainBranchRepository mainBranchRepository, ICompanyRepository companyRepository)
        {
            _mainBranchRepository = mainBranchRepository;
            _companyRepository = companyRepository;
        }

        public async Task<GetMainBranchQueryViewModel> Handle(GetMainBranchDetailsQuery request, CancellationToken cancellationToken)
        {
            var mainBranch = await _mainBranchRepository.GetById(request.Id,true);
            if (mainBranch is null)
                throw new Exception("The Main Branch Not Found");
            return new GetMainBranchQueryViewModel
            {
                Id = mainBranch.Id,
                Name = mainBranch.Name,
                Location = mainBranch.Location,
                CompanyId = mainBranch.CompanyId,
                CompanyName = _companyRepository.GetById(mainBranch.CompanyId, false).Result.Name,
                SecondaryBranches = mainBranch.SecondaryBranches,
                BasicProductions = mainBranch.BasicProductions,
                Distributions = mainBranch.Distributions,
            };
        }
    }
}
