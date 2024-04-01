using Application.Contracts;
using Application.Features.MainBranch.Commands.CreateMainBranch;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.AddBasicProduction
{
    public class AddBasicProductionCommandHandler : IRequestHandler<AddBasicProductionCommand>
    {
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ICompanyRepository _companyRepositor;
        private readonly IAsyncRepository<BasicProduction> _basicProductionRepository;
        public AddBasicProductionCommandHandler(IMainBranchRepository mainBranchRepository, ICompanyRepository companyRepositor, IAsyncRepository<BasicProduction> basicProductionRepository)
        {
            _mainBranchRepository = mainBranchRepository;
            _companyRepositor = companyRepositor;
            _basicProductionRepository = basicProductionRepository;
        }

        public async Task Handle(AddBasicProductionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddBasicProductionCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var company = await _companyRepositor.GetByName(request.CompanyName.ToLower(), false);
            if (company is null)
                throw new Exception("The Company Is Not Found");
            var mainBranch = await _mainBranchRepository.GetByName(request.MainBranchName.ToLower(),company.Id,false);
            if (mainBranch is null)
                throw new Exception("The Main Branch Is Not Found");
            var basicProduction = new BasicProduction
            {
                Id=Guid.NewGuid().ToString(),
                Amount=request.Amount,
                MainBranchId=mainBranch.Id,
                ProductionDate=request.DateOperation,
            };
            await _basicProductionRepository.AddAsync(basicProduction);
            return;
        }
    }
}
