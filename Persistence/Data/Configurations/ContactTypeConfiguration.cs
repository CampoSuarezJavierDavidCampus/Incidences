using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class ContactTypeConfiguration : IEntityTypeConfiguration<ContactType>{
    public void Configure(EntityTypeBuilder<ContactType> builder){
        builder.ToTable("contactType");
        
        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired()
            .HasColumnName("id_ContactType_Pk");

        builder.Property(p => p.Name)
            .HasColumnName("name_ContactType")
            .IsRequired()
            .HasMaxLength(100);
    }
}