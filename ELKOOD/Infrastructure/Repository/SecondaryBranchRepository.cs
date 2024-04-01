using Application.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class SecondaryBranchRepository : AsyncRepository<SecondaryBranch>, ISecondaryBranchRepository
    {
        private readonly ApplicationDbContext _context;
        public SecondaryBranchRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<SecondaryBranch> GetByName(string Name, string MainBranchId)
        {
            return await _context.SecondaryBranches.SingleOrDefaultAsync(o => o.Name == Name && o.MainBranchId == MainBranchId);
        }
    }
}
