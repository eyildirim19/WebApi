using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Ornek2.Models;

namespace WebApi.Ornek2.Mapping
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasColumnName("CategoryId");
            builder.Property(c => c.Name).HasColumnName("CategoryName").IsRequired();
            builder.Property(c => c.Desc).HasColumnName("Description");
            builder.ToTable("Categories");
        }
    }
}