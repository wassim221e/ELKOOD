using Application.Contracts;
using Domain.Enums;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.UpdateSecondaryBranch
{
    public class UpdateSecondaryBranchCommandHandler : IRequestHandler<UpdateSecondaryBranchCommand>
    {
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        private readonly IMainBranchRepository _mainBranchRepository;

        public UpdateSecondaryBranchCommandHandler(IMainBranchRepository mainBranchRepository, ISecondaryBranchRepository secondaryBranchRepository = null)
        {
            _mainBranchRepository = mainBranchRepository;
            _secondaryBranchRepository = secondaryBranchRepository;
        }

        public async Task Handle(UpdateSecondaryBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSecondaryBranchCommandValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var secondaryBranch = await _secondaryBranchRepository.GetById(request.Id.ToLower(),false);
            if (secondaryBranch is null)
                throw new Exception("The Secondary Branch Is Not Found");
            if (request.BranchType == BranchType.main.ToString())
            {
                var mainBranch = new Domain.Models.MainBranch
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = request.Name.ToLower(),
                    Location = request.Location.ToLower(),
                    CompanyId = _mainBranchRepository.GetById(secondaryBranch.MainBranchId,false).Result.CompanyId,
                    BasicProductions = [],
                    Distributions = [],
                    SecondaryBranches = [],
                };
                await _mainBranchRepository.AddAsync(mainBranch);
                await _secondaryBranchRepository.DeleteAsync(secondaryBranch);
            }
            else
            {
                secondaryBranch.Name = request.Name.ToLower();
                secondaryBranch.Location = request.Location.ToLower();
                await _secondaryBranchRepository.UpdateAsync(secondaryBranch);
            }
            return;
        }
    }
}
