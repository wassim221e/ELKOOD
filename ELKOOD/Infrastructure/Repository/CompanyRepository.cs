using Application.Contracts;
using Application.Features.Company.Queries.GetAllCompany;
using Application.Features.Company.Queries.GetCompanyDetails;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CompanyRepository:AsyncRepository<Company>,ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Company> GetByName(string Name, bool Details)
        {
            if (!Details)
                return await _context.Companies.SingleOrDefaultAsync(o => o.Name == Name);
            return await _context.Companies.Include(o=>o.MainBranches).SingleOrDefaultAsync(o => o.Name ==Name);
        }
        public override async Task<Company> GetById(string Id, bool Details)
        {
            if (!Details)
                return await _context.Companies.SingleOrDefaultAsync(o => o.Id == Id);
            return await _context.Companies.Include(o => o.MainBranches).ThenInclude(o=>o.SecondaryBranches).Include(o=>o.Products).SingleOrDefaultAsync(o=>o.Id==Id);
        }
        public override async Task<List<Company>> GetAllAsync(bool Details)
        {
            if (!Details)
                return await _context.Companies.ToListAsync();
            return await _context.Companies.Include(o => o.MainBranches).ToListAsync();
            
        }

    }
}
