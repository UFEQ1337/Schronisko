using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schronisko.Models;

namespace Schronisko.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Schronisko.Models.Shelter> Shelter { get; set; } = default!;
        public DbSet<Schronisko.Models.Animal> Animal { get; set; } = default!;
        public DbSet<Schronisko.Models.Owner> Owner { get; set; } = default!;
    }
}
