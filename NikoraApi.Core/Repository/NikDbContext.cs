using Microsoft.EntityFrameworkCore;
using NikoraApi.Domain.Models;

namespace NikoraApi.Core.Repository
{
    public class NikDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public NikDbContext()
        {

        }
        public NikDbContext(DbContextOptions<NikDbContext> options) : base(options)
        {

        }

    }
}
