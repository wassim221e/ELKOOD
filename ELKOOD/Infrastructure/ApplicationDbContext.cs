using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MainBranch> MainBranches { get; set; }
        public DbSet<SecondaryBranch> SecondaryBranches { get; set; }
        public DbSet<BasicProduction> BasicProductions { get; set; }
        public DbSet<Distribution> Distributions { get; set; }

    }
}
