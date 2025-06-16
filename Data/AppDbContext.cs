using Microsoft.EntityFrameworkCore;
using MusicSite.Models;

namespace MusicSite.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Song> Songs => Set<Song>();
    }
}
