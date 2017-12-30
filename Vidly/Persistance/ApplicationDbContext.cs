using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Vidly.Models;

namespace Vidly.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().Property(c => c.FirstName).IsRequired().HasMaxLength(255);
            builder.Entity<Customer>().Property(c => c.LastName).IsRequired().HasMaxLength(255);
            builder.Entity<Genre>().Property(c => c.Name).IsRequired().HasMaxLength(20);
            builder.Entity<Movie>().Property(c => c.Name).IsRequired().HasMaxLength(255);

        }
    }
}