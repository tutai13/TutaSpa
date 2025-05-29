using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;

using TutaSpa_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TutaSpa_API.Data
{
    public class ApplicationDBContext :  IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        // --------------------------
       

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Id)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }

}
