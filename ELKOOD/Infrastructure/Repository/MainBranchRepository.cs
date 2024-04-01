using Application.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class MainBranchRepository : AsyncRepository<MainBranch>, IMainBranchRepository
    {
        private readonly ApplicationDbContext _context;
        public MainBranchRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<MainBranch> GetByName(string Name, string CompanyId,bool Details)
        {
            if (!Details)
                return await _context.MainBranches.SingleOrDefaultAsync(o => o.CompanyId == CompanyId && o.Name == Name);

            return await _context.MainBranches.Include(o=>o.SecondaryBranches).Include(o=>o.BasicProductions).Include(o=>o.Distributions).SingleOrDefaultAsync(o => o.CompanyId == CompanyId && o.Name == Name);
        }
        public override async Task<MainBranch> GetById(string Id,bool Details)
        {
            if (!Details)
                return await _context.MainBranches.SingleOrDefaultAsync(o => o.Id == Id);
            return await _context.MainBranches.Include(o => o.SecondaryBranches).Include(o=>o.BasicProductions).Include(o=>o.Distributions).SingleOrDefaultAsync(o => o.Id == Id);
        }
        public override async Task<List<MainBranch>> GetAllAsync(bool Details)
        {
            if (!Details)
                return await _context.MainBranches.ToListAsync();
            return await _context.MainBranches.Include(o => o.SecondaryBranches).Include(o=>o.Distributions).Include(o=>o.BasicProductions).ToListAsync(); 
        }
        public async Task<float> GetBasicProductionRange(string MainBranchId, DateTime Start, DateTime End)
        {
            End=End.AddSeconds(1);
            var basicProductions = await _context.BasicProductions.Where(o => o.MainBranchId == MainBranchId && o.ProductionDate <= End && o.ProductionDate >= Start).ToListAsync();
            float result = 0;
            foreach (var basicProduction in basicProductions)
                result += basicProduction.Amount;
            return result;
        }
    }
}
