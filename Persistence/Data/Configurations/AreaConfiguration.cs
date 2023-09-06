using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class AreaConfiguration : IEntityTypeConfiguration<Area>
{
    public void Configure(EntityTypeBuilder<Area> builder)
    {
        builder.ToTable("area");        

        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasColumnName("id_Area_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name_Area")
            .IsRequired()
            .HasMaxLength(50);        
    }
}