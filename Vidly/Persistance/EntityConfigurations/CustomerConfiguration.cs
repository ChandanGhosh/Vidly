using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vidly.Models;

namespace Vidly.Persistance.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(c => c.LastName).IsRequired().HasMaxLength(255);
        }
    }
}