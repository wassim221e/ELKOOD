using Application.Contracts;
using Application.Features.MainBranch.Commands.CreateMainBranch;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.MainBranch.Queries.GetBasicProductionRange
{
    public class GetBasicProductionRangeQueryHandler : IRequestHandler<GetBasicProductionRangeQuery, float>
    {
        private readonly IMainBranchRepository _mainBranchRepository;

        public GetBasicProductionRangeQueryHandler(IMainBranchRepository mainBranchRepository)
        {
            _mainBranchRepository = mainBranchRepository;
        }

        public async Task<float> Handle(GetBasicProductionRangeQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBasicProductionRangeQueryValidator();
            var result = await validator.ValidateAsync(request);
            if (!result.IsValid)
            {
                string Errors = string.Empty;
                foreach (var error in result.Errors)
                    Errors += $"{error}. \n";
                throw new Exception(Errors);
            }
            var mainBranch = await _mainBranchRepository.GetById(request.MainBranchId, false);
            if (mainBranch is null)
                throw new Exception("The Main Branch Is Not Found");
            return await _mainBranchRepository.GetBasicProductionRange(request.MainBranchId, request.Start, request.End);
        }
    }
}
