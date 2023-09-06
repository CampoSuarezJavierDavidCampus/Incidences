using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class IncidenceConfiguration : IEntityTypeConfiguration<Incidence>{
    public void Configure(EntityTypeBuilder<Incidence> builder){
        builder.ToTable("incidence");

        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .HasColumnName("id_Incidence_Pk")
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description_Incidence")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Date)
            .HasColumnName("date_Incidence")
            .IsRequired()
            .HasColumnType("Date");

        builder.Property(p => p.IdPersonFk)
            .HasColumnName("id_Person_Fk")
            .IsRequired();
        builder.Property(p => p.IdStateFk)
            .HasColumnName("id_State_Fk")
            .IsRequired();
        builder.Property(p => p.IdAreaFk)
            .HasColumnName("id_Area_Fk")
            .IsRequired();
        builder.Property(p => p.IdPlaceFk)
            .HasColumnName("id_Place_Fk")
            .IsRequired();
         
       
        builder.HasOne(y => y.Person)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.IdPersonFk)
            .IsRequired();

        builder.HasOne(y => y.Areas)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.IdAreaFk)
            .IsRequired();
         
        builder.HasOne(y => y.States)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.IdStateFk)
            .IsRequired();

        builder.HasOne(y => y.Place)
            .WithMany(l => l.Incidences)
            .HasForeignKey(z => z.IdPlaceFk)
            .IsRequired();
    }
}