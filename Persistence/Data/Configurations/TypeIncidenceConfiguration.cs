using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class TypeIncidenceConfiguration : IEntityTypeConfiguration<TypeIncidence>
    {
        public void Configure(EntityTypeBuilder<TypeIncidence> builder)
        {
            builder.ToTable("typeIncidence");
            
            builder.HasKey(x => x.IdPk);

            builder.Property(p => p.IdPk)
            .HasColumnName("id_TypeIncidence_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .IsRequired();
            
            builder.Property(p => p.Name)
                .HasColumnName("name_TypeIncidence")
                .IsRequired()
                .HasMaxLength(50);
                
            builder.Property(p => p.Description)
                .HasColumnName("description_TypeIncidence")
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}