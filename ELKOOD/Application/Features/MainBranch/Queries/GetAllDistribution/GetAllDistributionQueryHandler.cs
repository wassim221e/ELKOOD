using Application.Contracts;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetAllDistribution
{
    public class GetAllDistributionQueryHandler : IRequestHandler<GetAllDistributionQuery, List<GetAllDistributionViewModel>>
    {
        private readonly IAsyncRepository<Distribution> _distributionRepository;
        private readonly IMainBranchRepository _mainBranchRepository;
        private readonly ISecondaryBranchRepository _secondaryBranchRepository;
        public GetAllDistributionQueryHandler(IAsyncRepository<Distribution> distributionRepository, IMainBranchRepository mainBranchRepository, ISecondaryBranchRepository secondaryBranchRepository)
        {
            _distributionRepository = distributionRepository;
            _mainBranchRepository = mainBranchRepository;
            _secondaryBranchRepository = secondaryBranchRepository;
        }

        public async Task<List<GetAllDistributionViewModel>> Handle(GetAllDistributionQuery request, CancellationToken cancellationToken)
        {
            if (request.MainBranchId is not null && await _mainBranchRepository.GetById(request.MainBranchId, false) is null)
                throw new Exception($"The Main Branch By Id :{request.MainBranchId} Is Not Found");
            var distributiones = _distributionRepository.GetAllAsync(false).Result.Where(o => o.MainBranchId == (request.MainBranchId is not null ? request.MainBranchId : o.MainBranchId))
                .Select
                (
                    p =>
                        new GetAllDistributionViewModel
                        {
                            Id = p.Id,
                            Amount = p.Amount,
                            DateOperation = p.DateOperation,
                            MainBranchId = p.MainBranchId,
                            MainBranchName = _mainBranchRepository.GetById(p.MainBranchId, false).Result.Name,
                            SecondaryBranchId = p.SecondaryBranchId,
                            SecondaryBranchName = _secondaryBranchRepository.GetById(p.SecondaryBranchId, false).Result.Name
                        }
                ).ToList();
            return distributiones;
                
        }
    }
}