using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class CategoryContactConfiguration : IEntityTypeConfiguration<CategoryContact>{
    public void Configure(EntityTypeBuilder<CategoryContact> builder){
        builder.ToTable("categoryContact");

        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasColumnName("id_CategoryContact_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name_CategoryContact")
            .HasMaxLength(50)
            .IsRequired();        
    }
}