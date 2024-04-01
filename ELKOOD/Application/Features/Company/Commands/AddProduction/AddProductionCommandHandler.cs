using Application.Contracts;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Company.Commands.AddProduction
{
    public class AddProductionCommandHandler : IRequestHandler<AddProductionCommand>
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IAsyncRepository<Product> _asyncRepository;
        public AddProductionCommandHandler(ICompanyRepository companyRepository, IAsyncRepository<Product> asyncRepository = null)
        {
            _companyRepository = companyRepository;
            _asyncRepository = asyncRepository;
        }

        public async Task Handle(AddProductionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductionCommandValidator();
            var result =await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var Company = await _companyRepository.GetByName(request.CompanyName.ToLower(), false);
            if (Company is null)
                throw new Exception($"The Company By Name :{request.CompanyName} Is Not Found");
            var product = new Product
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name.ToLower(),
                CompanyId = Company.Id,
                Type = request.Type.ToLower(),
            };
            await _asyncRepository.AddAsync(product);
            return;
        }
    }
}
