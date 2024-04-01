using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IAsyncRepository<T>where T:class
    {
        Task <T>AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task DeleteAsync(T model);
        Task<T> GetById(string Id,bool Details);
        Task<List<T>>GetAllAsync(bool Details);
    }
}
