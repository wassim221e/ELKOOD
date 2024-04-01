using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IMainBranchRepository:IAsyncRepository<MainBranch>
    {
        Task<MainBranch> GetByName(string Name, string CompanyId,bool Details);
        Task<float> GetBasicProductionRange(string MainBranchId, DateTime Start, DateTime End);
    }
}
