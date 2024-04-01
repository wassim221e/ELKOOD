using Application.Contracts;
using Application.Features.Company.Queries.GetAllCompany;
using Domain.Enums;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetAllMainBranch
{
    public class GetAllBranchQueryHandler : IRequestHandler<GetAllMainBranchQuery,List<GetAllBranchViewModel>>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMainBranchRepository _mainBranchRepository;
        public GetAllBranchQueryHandler(ICompanyRepository companyRepository, IMainBranchRepository mainBranchRepository)
        {
            _companyRepository = companyRepository;
            _mainBranchRepository = mainBranchRepository;
        }

        public async Task<List<GetAllBranchViewModel>> Handle(GetAllMainBranchQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllMainBranchQueryValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            
            if(request.CompanyName is null ||Enum.GetNames(typeof(StateOfCompanyQuery)).Contains(request.CompanyName.ToLower()))
            {
                var companies = _companyRepository.GetAllAsync(true).Result.Where(o => o.State == (request.CompanyName is not null ? request.CompanyName.ToLower() : o.State)).ToList();
                var mainBranches = new List<GetAllBranchViewModel>();
                foreach (var company in companies)
                {
                    foreach (var mainBranch in company.MainBranches)
                    {
                        var mainBranchViewModel = new GetAllBranchViewModel
                        {
                            Name=mainBranch.Name,
                            Id=mainBranch.Id,
                            CompanyId=mainBranch.CompanyId,
                            CompanyName= company.Name,
                            Location= mainBranch.Location,
                        };
                        mainBranches.Add(mainBranchViewModel);
                    }
                    
                }
                return mainBranches;
            }
            var Company = await _companyRepository.GetByName(request.CompanyName.ToLower(),true);
            if (Company is null)
                throw new Exception("The Company Not Found");
            var mainbranches =new List<GetAllBranchViewModel>();
            foreach (var mainBranch in Company.MainBranches)
            {
                var mainBranchViewModel = new GetAllBranchViewModel
                {
                    Name = mainBranch.Name,
                    Id = mainBranch.Id,
                    CompanyId = mainBranch.CompanyId,
                    CompanyName = Company.Name,
                    Location = mainBranch.Location,
                };
                mainbranches.Add(mainBranchViewModel);
            }
            return mainbranches;
        }
    }
}
