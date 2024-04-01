using Application.Contracts;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.CreateSecondaryBranch
{
    public class CreateSecondaryBranchCommandHandler : IRequestHandler<CreateSecondaryBranchCommand, Domain.Models.SecondaryBranch>
    {
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ICompanyRepository _companyRepository;
        public CreateSecondaryBranchCommandHandler(ISecondaryBranchRepository secondaryBranchRepository, IMainBranchRepository mainBranchRepository, ICompanyRepository companyRepository)
        {
            _secondaryBranchRepository = secondaryBranchRepository;
            _mainBranchRepository = mainBranchRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Domain.Models.SecondaryBranch> Handle(CreateSecondaryBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSecondaryBranchCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var company = await _companyRepository.GetByName(request.CompanyName, false);
            if (company is null)
                throw new Exception("The Company Is Not Found");
            var mainBranch = await _mainBranchRepository.GetByName(request.MainBranchName.ToLower(),company.Id,false);
            if (mainBranch is null)
                throw new Exception("The Main Branch Is Not Found");
            if (await _secondaryBranchRepository.GetByName(request.Name.ToLower(), mainBranch.Id) is not null)
                throw new Exception("The Secondary Branch  Name Is Already Exists");
            var secondaryBranch = new Domain.Models.SecondaryBranch
            {
                Id = Guid.NewGuid().ToString(),
                Location = request.Location.ToLower(),
                Name = request.Name.ToLower(),
                MainBranchId = mainBranch.Id,
            };
            return await _secondaryBranchRepository.AddAsync(secondaryBranch);
        }
    }
}
