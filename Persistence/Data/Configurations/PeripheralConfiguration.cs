using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class PeripheralConfiguration : IEntityTypeConfiguration<Peripheral>
{
    public void Configure(EntityTypeBuilder<Peripheral> builder)
    {
        builder.ToTable("peripheral");
        
        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasColumnName("id_Peripheral_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name_Peripheral")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.IdDetailIncidenceFk)
            .HasColumnName("id_DetailIncidence_Fk")
            .IsRequired()
            .HasMaxLength(50);


        builder.HasOne(y => y.DetailIncidence)
            .WithMany(l => l.Peripherals)
            .HasForeignKey(z => z.IdDetailIncidenceFk)
            .IsRequired();
    }
}