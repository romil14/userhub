using Microsoft.EntityFrameworkCore;
using uh.Entities.Models;

namespace uh.Entities.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
