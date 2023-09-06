using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class PlaceConfiguration : IEntityTypeConfiguration<Place>{
    public void Configure(EntityTypeBuilder<Place> builder){
        builder.ToTable("place");
        
        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasColumnName("id_Place_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name_Place")
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.IdAreaFk)
            .HasColumnName("id_Area_Fk")
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(y => y.Area)
            .WithMany(l => l.Places)
            .HasForeignKey(z => z.IdAreaFk)
            .IsRequired();
    }
}