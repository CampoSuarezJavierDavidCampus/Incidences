using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>{
    public void Configure(EntityTypeBuilder<DocumentType> builder){
        builder.ToTable("documentType");

        builder.HasKey(x => x.IdPk);

        builder.Property(p => p.IdPk)
            .HasColumnName("id_DocumentType_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name_DocumentType")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Abbreviation)
            .IsRequired()
            .HasColumnName("abbreviation_DocumentType")
            .HasMaxLength(20);
    }
}