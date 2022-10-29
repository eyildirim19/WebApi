using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Ornek2.Models;

namespace WebApi.Ornek2.Mapping
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(c => c.ID).HasColumnName("CustomerID");
            builder.Property(c => c.Contact).HasColumnName("ContactName");
            builder.ToTable("Customers");
        }
    }
}
