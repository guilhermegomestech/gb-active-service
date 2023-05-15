using gb_active_service_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace gb_active_service_api.Data.Mappings
{
    public class ResponsibleMapping : IEntityTypeConfiguration<Responsible>
    {
        public void Configure(EntityTypeBuilder<Responsible> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnType("VARCHAR(200)");

            builder.Property(t => t.Phone)
                .IsRequired()
                .HasColumnType("VARCHAR(20)");

            builder.Property(t => t.Email)
                .IsRequired()
                .HasColumnType("VARCHAR(100)");

            /*-----------------*/
            builder.HasMany(r => r.Actives)
                .WithOne(a => a.Responsible)
                .HasForeignKey(a => a.ResponsibleId);

            builder.ToTable("Responsibles");
        }
    }
}
