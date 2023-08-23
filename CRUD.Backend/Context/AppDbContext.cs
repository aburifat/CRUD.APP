using CRUD.Backend.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Backend.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Crud> Crud { get; set; }
    }
}
