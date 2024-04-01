using Application.Contracts;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.CreateMainBranch
{
    public class CreateMainBranchCommandHandler : IRequestHandler<CreateMainBranchCommand, Domain.Models.MainBranch>
    {
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        private readonly ICompanyRepository _companyRepository;

        public CreateMainBranchCommandHandler(IMainBranchRepository mainBranchRepository, ISecondaryBranchRepository secondaryBranchRepository, ICompanyRepository companyRepository)
        {
            _mainBranchRepository = mainBranchRepository;
            _secondaryBranchRepository = secondaryBranchRepository;
            _companyRepository = companyRepository;
        }

        public async Task<Domain.Models.MainBranch> Handle(CreateMainBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMainBranchCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var Company = await _companyRepository.GetByName(request.CompanyName.ToLower(),false);
            if (Company is null)
                throw new Exception($"The Company By Name {request.CompanyName} Is Not Found");
            if (await _mainBranchRepository.GetByName(request.Name.ToLower(), Company.Id,false) is not null)
                throw new Exception($"The Branch Name Is Already Exists");
            var mainBranch = new Domain.Models.MainBranch
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name.ToLower(),
                Location = request.Location.ToLower(),
                CompanyId = Company.Id,
                BasicProductions = [],
                Distributions = [],
                SecondaryBranches = [],
            };
            return await _mainBranchRepository.AddAsync(mainBranch);
        }
    }
}
