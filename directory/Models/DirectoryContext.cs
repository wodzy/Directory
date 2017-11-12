using Microsoft.EntityFrameworkCore;
namespace directoryApi.Models
{
    public class DirectoryContext : DbContext
    {
        public DirectoryContext(DbContextOptions<DirectoryContext> options)
            : base(options)
        {
        }

        public DbSet<DirectoryItem> DirectoryItems { get; set; }
    }
}