using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ArtistModel> Artist { get; set; }
        public DbSet<TattooModel> Tattoo { get; set; }
    }
}
