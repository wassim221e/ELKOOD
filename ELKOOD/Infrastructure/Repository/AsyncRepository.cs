using Application.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public AsyncRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> AddAsync(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
            return;
        }

        public virtual async Task<List<T>> GetAllAsync(bool Details)
        {
            var result = await _context.Set<T>().ToListAsync<T>();
            return result;
        }

        public virtual async Task<T> GetById(string Id, bool Details)
        {
            var result = await _context.Set<T>().FindAsync(Id);
            return result;
        }
        public async Task<T> UpdateAsync(T model)
        {
            _context.Set<T>().Update(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
