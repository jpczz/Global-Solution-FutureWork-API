using Microsoft.EntityFrameworkCore;
using FutureWork.API.Models;

namespace FutureWork.API.Data
{
    public class FutureWorkDbContext : DbContext
    {
        public FutureWorkDbContext(DbContextOptions<FutureWorkDbContext> options)
            : base(options)
        {
        }

        public DbSet<Skill> Skills { get; set; } = null!;
    }
}
