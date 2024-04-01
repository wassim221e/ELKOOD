using Application.Contracts;
using Application.Features.SecondaryBranch.Commands.CreateSecondaryBranch;
using Domain.Enums;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SecondaryBranch.Queries.GetAllSecondaryBranch
{
    public class GetAllSecondaryBranchQueryHandler : IRequestHandler<GetAllSecondaryBranchQuery, List<GetAllSecondaryBranchViewModel>>
    {
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        public GetAllSecondaryBranchQueryHandler(IMainBranchRepository mainBranchRepository, ISecondaryBranchRepository secondaryBranchRepository)
        {
            _mainBranchRepository = mainBranchRepository;
            _secondaryBranchRepository = secondaryBranchRepository;
        }

        public async Task<List<GetAllSecondaryBranchViewModel>> Handle(GetAllSecondaryBranchQuery request, CancellationToken cancellationToken)
        {

            var mainBranch = await _mainBranchRepository.GetById(request.MainBranchId, false);
            if (request.MainBranchId is not null && mainBranch is null)
                throw new Exception($"The Main Branch By Id{request.MainBranchId} Is Not Found");
            var secondaryBranches = _secondaryBranchRepository.GetAllAsync(false).Result.Where(o => o.MainBranchId == (request.MainBranchId is not null ? mainBranch.Id : o.MainBranchId)).Select
                (o =>
                 new GetAllSecondaryBranchViewModel
                 {
                     Id = o.Id,
                     Name = o.Name,
                     Location = o.Location,
                     MainBranchId = o.MainBranchId,
                     MainBranchName = _mainBranchRepository.GetById(o.MainBranchId, false).Result.Name,
                 }
                ).ToList();
            return secondaryBranches;
        }
    }
}
