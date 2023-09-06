using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("person");

        builder.HasKey(x => x.IdPk);

        builder.Property(p => p.IdPk)                     
            .HasColumnName("id_Person_Pk")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name_Person")
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p => p.Lastname)
            .HasColumnName("lastname_Person")
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(p => p.Address)
            .HasColumnName("address_Person")
            .IsRequired()
            .HasMaxLength(200);


        builder.Property(p => p.IdDocumentTypeFk)
            .HasColumnName("id_DocumentType_Fk")
            .IsRequired();

        builder.Property(p => p.IdUserFk)
            .HasColumnName("id_User_Fk")
            .IsRequired();
                 

        builder.HasOne(u => u.DocumentType)
        .WithMany(a => a.Person)
        .HasForeignKey(u => u.IdDocumentTypeFk);

        builder.HasOne(u => u.User)
        .WithMany(a => a.Person)
        .HasForeignKey(u => u.IdUserFk);
    }
}