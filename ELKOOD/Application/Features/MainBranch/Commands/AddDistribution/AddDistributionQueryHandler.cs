using Application.Contracts;
using Application.Features.MainBranch.Queries.GetBasicProductionRange;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.AddDistribution
{
    public class AddDistributionQueryHandler : IRequestHandler<AddDistributionQuery>
    {
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        private readonly IAsyncRepository<Distribution> _distributionRepository;
        public AddDistributionQueryHandler(IMainBranchRepository mainBranchRepository, ICompanyRepository companyRepository, ISecondaryBranchRepository secondaryBranchRepository, IAsyncRepository<Distribution> distributionRepository)
        {
            _mainBranchRepository = mainBranchRepository;
            _companyRepository = companyRepository;
            _secondaryBranchRepository = secondaryBranchRepository;
            _distributionRepository = distributionRepository;
        }

        public async Task Handle(AddDistributionQuery request, CancellationToken cancellationToken)
        {
            var validator = new AddDistributionQueryValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var company = await _companyRepository.GetByName(request.CompanyName.ToLower(), false);
            if (company is null)
                throw new Exception("The Company Is Not Found");
            var mainBranch = await _mainBranchRepository.GetByName(request.MainBranchName.ToLower(),company.Id, false);
            if (mainBranch is null)
                throw new Exception("The Main Branch Is Not Found");
            var secondaryBranch = await _secondaryBranchRepository.GetByName(request.SecondaryBranchName.ToLower(), mainBranch.Id);
            if (secondaryBranch is null)
                throw new Exception("The Secondary Branch Is Not Found");
            await _distributionRepository.AddAsync(new Distribution
            {
                Id=Guid.NewGuid().ToString(),
                Amount=request.Amount,
                DateOperation=request.DateOperation,
                MainBranchId=mainBranch.Id,
                SecondaryBranchId=secondaryBranch.Id,
            });
            return;
        }
    }
}
