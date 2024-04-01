using Application.Contracts;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Commands.DeleteMainBranch
{
    public class DeleteMainBranchCommandHandler : IRequestHandler<DeleteMainBranchCommand>
    {
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        private readonly IAsyncRepository<BasicProduction> _basicProductionRepository;
        public DeleteMainBranchCommandHandler(IMainBranchRepository mainBranchRepository, ISecondaryBranchRepository secondaryBranchRepository, IAsyncRepository<BasicProduction> basicProductionRepository)
        {
            _mainBranchRepository = mainBranchRepository;
            _secondaryBranchRepository = secondaryBranchRepository;
            _basicProductionRepository = basicProductionRepository;
        }
        public async Task Handle(DeleteMainBranchCommand request, CancellationToken cancellationToken)
        {
            var mainBranch = await _mainBranchRepository.GetById(request.Id,true);
            if (mainBranch is null)
                throw new Exception($"The Main Branch By Id {request.Id} Is Not Found");
            var secondaryBranches = mainBranch.SecondaryBranches;
            foreach (var secondaryBranch in secondaryBranches)
                await _secondaryBranchRepository.DeleteAsync(secondaryBranch);
            foreach (var basicProduction in mainBranch.BasicProductions)
                await _basicProductionRepository.DeleteAsync(basicProduction);
            await _mainBranchRepository.DeleteAsync(mainBranch);
            return;
        }
    }
}
