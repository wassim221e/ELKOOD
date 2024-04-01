using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Commands.DeleteSecondaryBranch
{
    public class DeleteSecondaryBranchCommandHandler : IRequestHandler<DeleteSecondaryBranchCommand>
    {
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;

        public DeleteSecondaryBranchCommandHandler(ISecondaryBranchRepository secondaryBranchRepository)
        {
            _secondaryBranchRepository = secondaryBranchRepository;
        }

        public async Task Handle(DeleteSecondaryBranchCommand request, CancellationToken cancellationToken)
        {
            var secondaryBranch = await _secondaryBranchRepository.GetById(request.Id, false);
            if (secondaryBranch is null)
                throw new Exception("The Secondary Branch is NOt Found");
            await _secondaryBranchRepository.DeleteAsync(secondaryBranch);
            return;
        }
    }
}
