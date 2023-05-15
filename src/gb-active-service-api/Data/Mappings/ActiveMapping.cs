using gb_active_service_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gb_active_service_api.Data.Mappings
{
    public class ActiveMapping : IEntityTypeConfiguration<Active>
    {
        public void Configure(EntityTypeBuilder<Active> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(t => t.Brand)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            /*-----------------*/
            
            builder.ToTable("Actives");
        }
    }
}
