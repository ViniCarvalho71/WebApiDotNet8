using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class AppDbContext(DbContextOptions options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<ArtistModel> Artist { get; set; }
        public DbSet<TattooModel> Tattoo { get; set; }
    }
}
