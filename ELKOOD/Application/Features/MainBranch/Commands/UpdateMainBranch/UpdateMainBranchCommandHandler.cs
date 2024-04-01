using Application.Contracts;
using Domain.Enums;
using Domain.Models;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.UpdateMainBranch
{
    public class UpdateMainBranchCommandHandler : IRequestHandler<UpdateMainBranchCommand>
    {
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAsyncRepository<BasicProduction> _basicProductionRepository;
        private readonly IAsyncRepository<Distribution> _distributionRepository;

        public UpdateMainBranchCommandHandler(IMainBranchRepository mainBranchRepository, ISecondaryBranchRepository secondaryBranchRepository, ICompanyRepository companyRepository, IAsyncRepository<BasicProduction> basicProductionRepository, IAsyncRepository<Distribution> distributionRepository)
        {
            _mainBranchRepository = mainBranchRepository;
            _secondaryBranchRepository = secondaryBranchRepository;
            _companyRepository = companyRepository;
            _basicProductionRepository = basicProductionRepository;
            _distributionRepository = distributionRepository;
        }

        public async Task Handle(UpdateMainBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMainBranchCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var mainBranch = await _mainBranchRepository.GetById(request.Id,true);
            if (mainBranch is null)
                throw new Exception($"The Main Branch By Id {request.Id} Is Not Found");
            if (request.BranchType == BranchType.secondary.ToString())
            {
                var company = await _companyRepository.GetById(mainBranch.CompanyId, false);
                var newMainBranch = await _mainBranchRepository.GetByName(request.mainBranchName.ToLower(),company.Id,true);
                if (newMainBranch is null)
                    throw new Exception("the main Branch is null");
                var checkName = await _secondaryBranchRepository.GetByName(request.Name.ToLower(), newMainBranch.Id);
                if (checkName is not null)
                    throw new Exception($"The Name :{request.Name.ToLower()} Is Already Exists in Secondary Branch For Company {company.Name}");
                foreach (var basicProduction in mainBranch.BasicProductions)
                {
                    basicProduction.MainBranchId = newMainBranch.Id;
                    await _basicProductionRepository.UpdateAsync(basicProduction);
                }
                foreach (var SecondaryBranch in mainBranch.SecondaryBranches)
                {
                    SecondaryBranch.MainBranchId = newMainBranch.Id;
                    await _secondaryBranchRepository.UpdateAsync(SecondaryBranch);
                }
                foreach(var distribution in mainBranch.Distributions)
                {
                    distribution.MainBranchId = newMainBranch.Id;
                    await _distributionRepository.UpdateAsync(distribution);
                }
                var secondaryBranch = new Domain.Models.SecondaryBranch
                {
                    Id = Guid.NewGuid().ToString(),
                    Location = request.Location.ToLower(),
                    MainBranchId = newMainBranch.Id,
                    Name = request.Name.ToLower(),
                };
                await _secondaryBranchRepository.AddAsync(secondaryBranch);
                foreach (var basicProduction in mainBranch.BasicProductions)
                    await _basicProductionRepository.DeleteAsync(basicProduction);
                await _mainBranchRepository.DeleteAsync(mainBranch);
            }
            else
            {
                mainBranch.Name = request.Name.ToLower();
                mainBranch.Location = request.Location.ToLower();
                await _mainBranchRepository.UpdateAsync(mainBranch);
            }
            return;
        }
    }
}
