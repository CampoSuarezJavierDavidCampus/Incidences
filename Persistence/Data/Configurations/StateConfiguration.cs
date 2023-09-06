using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;
public class StateConfiguration : IEntityTypeConfiguration<State>{
    public void Configure(EntityTypeBuilder<State> builder){
        builder.ToTable("state");        

        builder.HasKey(x => x.IdPk);
        
        builder.Property(p => p.IdPk)
            .HasColumnName("id_State_Pk")
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .IsRequired();
        
        builder.Property(p => p.Description)
            .HasColumnName("description_State")
            .HasMaxLength(100)
            .IsRequired();        
    }
}