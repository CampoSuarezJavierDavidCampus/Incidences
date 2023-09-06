using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class LevelIncidenceConfiguration : IEntityTypeConfiguration<LevelIncidence>{   
    public void Configure(EntityTypeBuilder<LevelIncidence> builder)
    {
        builder.ToTable("levelIncidence");
        
        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasColumnName("id_LevelIncidence_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name_LevelIncidence")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Description)            
            .HasColumnName("description_LevelIncidence")
            .IsRequired()
            .HasMaxLength(100);
    }
}