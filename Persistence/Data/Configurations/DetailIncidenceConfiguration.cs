using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class DetailIncidenceConfiguration : IEntityTypeConfiguration<DetailIncidence>{
    public void Configure(EntityTypeBuilder<DetailIncidence> builder){
        builder.ToTable("detailIncidence");
        
        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasColumnName("id_DetailIncidence_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)            
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnName("description_DetailIncidence")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.IdIncidenceFk)
            .HasColumnName("id_Incidence_Fk")
            .IsRequired();

        builder.Property(p => p.IdPeripheralFk)
            .HasColumnName("id_Peripheral_Fk")
            .IsRequired();

        builder.Property(p => p.IdTypeIncidenceFk)
            .HasColumnName("id_TypeIncidence_Fk")
            .IsRequired();

        builder.Property(p => p.IdLevelIncidenceFk)
            .HasColumnName("id_LevelIncidence_Fk")
            .IsRequired();


        builder.HasOne(y => y.Incidence)
            .WithMany(l => l.DetailIncidences)
            .HasForeignKey(z => z.IdIncidenceFk)
            .IsRequired();
            
        builder.HasOne(y => y.State)
            .WithMany(l => l.DetailIncidences)
            .HasForeignKey(z => z.IdStateFk)
            .IsRequired();

        builder.HasOne(y => y.TypeIncidence)
            .WithMany(l => l.DetailIncidences)
            .HasForeignKey(z => z.IdTypeIncidenceFk)
            .IsRequired();

        builder.HasOne(y => y.LevelOfIncidence)
            .WithMany(l => l.DetailIncidences)
            .HasForeignKey(z => z.IdLevelIncidenceFk)
            .IsRequired();            
    }
} 