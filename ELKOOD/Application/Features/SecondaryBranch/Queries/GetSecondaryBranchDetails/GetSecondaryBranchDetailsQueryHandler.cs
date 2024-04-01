using Application.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Queries.GetSecondaryBranchDetails
{
    public class GetSecondaryBranchDetailsQueryHandler : IRequestHandler<GetSecondaryBranchDetailsQuery, GetSecondaryBranchDetailsViewModel>
    {
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        private readonly IMainBranchRepository _mainBranchRepository;
        public GetSecondaryBranchDetailsQueryHandler(ISecondaryBranchRepository secondaryBranchRepository, IMainBranchRepository mainBranchRepository)
        {
            _secondaryBranchRepository = secondaryBranchRepository;
            _mainBranchRepository = mainBranchRepository;
        }

        public async Task<GetSecondaryBranchDetailsViewModel> Handle(GetSecondaryBranchDetailsQuery request, CancellationToken cancellationToken)
        {
            var secondaryBranch = await _secondaryBranchRepository.GetById(request.Id,false);
            if (secondaryBranch is null)
                throw new Exception("The Secondary Branch is not found");
            return new GetSecondaryBranchDetailsViewModel
            {
                Id=secondaryBranch.Id,
                Name = secondaryBranch.Name,
                Location = secondaryBranch.Location,
                MainBranchId= secondaryBranch.MainBranchId,
                MainBranchName= _mainBranchRepository.GetById(secondaryBranch.MainBranchId, false).Result.Name
            };
        }
    }
}
