using gb_active_service_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gb_active_service_api.Data.Mappings
{
    public class DependencyMapping : IEntityTypeConfiguration<Dependency>
    {
        public void Configure(EntityTypeBuilder<Dependency> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Description)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(t => t.Address)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            /*-----------------*/
            builder.HasMany(d => d.Actives)
                .WithOne(a => a.Dependency)
                .HasForeignKey(a => a.DependencyId);

            builder.ToTable("Dependencies");
        }
    }
}
