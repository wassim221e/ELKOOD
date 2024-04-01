using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
namespace Application.Features.Company.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand,Domain.Models.Company>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Domain.Models.Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCompanyCommandValdator();
            var result = await validator.ValidateAsync(request);
            if(!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            if (await _companyRepository.GetByName(request.Name.ToLower(),false) is not null)
                throw new Exception($"The Company Name Is Exists Already Try Different Name ");
            var Company = new Domain.Models.Company
            {
                Id=Guid.NewGuid().ToString(),
                Name=request.Name.ToLower(),
                State=request.State.ToLower(),
                DateOfEstablishment=request.DateOfEstablishment,
                Location=request.Location.ToLower(),
                MainBranches = [],
                Products = [],
            };
            Company = await _companyRepository.AddAsync(Company);
            return Company;
        }
    }
}
