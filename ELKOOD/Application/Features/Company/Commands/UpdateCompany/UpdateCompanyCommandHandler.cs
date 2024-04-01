using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Domain.Models.Company>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandHandler(Contracts.ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Domain.Models.Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCompanyCommandValidator();
            var result=validator.Validate(request);
            if(!result.IsValid)
            {
                if (!result.IsValid)
                {
                    string Errors = string.Empty;
                    foreach (var error in result.Errors)
                        Errors += $"{error}. \n";
                    throw new Exception(Errors);
                }
            }
            var company = await _companyRepository.GetById(request.Id,false);
            if (company is null)
                throw new Exception($"The Company By Id {request.Id} Is Not Found");
            var CheckName = await _companyRepository.GetByName(request.Name.ToLower(),false);
            if (CheckName is not null && CheckName.Id != request.Id)
                throw new Exception($"The Company Name Is Already Exists");
            company.Name = request.Name.ToLower();
            company.Location = request.Location.ToLower();
            company.State = request.State.ToLower();
            company=await _companyRepository.UpdateAsync(company);
            return company;
        }
    }
}
