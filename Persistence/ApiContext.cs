using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options): base(options){}
    public DbSet<Area> Areas { get; set; }
    public DbSet<CategoryContact> CategoryContacts { get; set; }
    public DbSet<ContactType> ContactTypes { get; set; }
    public DbSet<DetailIncidence> DetailIncidences { get; set; }
    public DbSet<DocumentType> DocumentTypes { get; set; }
    public DbSet<Incidence> Incidences { get; set; }
    public DbSet<LevelIncidence> LevelIncidences { get; set; }
    public DbSet<Peripheral> Peripherals { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<RolUser> RolUsers { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<TypeIncidence> TypeIncidences { get; set; }
    public DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {            
        modelBuilder.Entity<Contact>()            
            .HasKey(x => new{x.IdCategoryContactPk,x.IdTypeContactPk,x.IdPersonPk});
        modelBuilder.Entity<Contact>()
            .Property(x => x.Description)
            .HasColumnName("description_Contact")
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<Contact>()
            .Property(x => x.IdPersonPk)
            .IsRequired()
            .HasColumnName("id_Person_Pk");            

        modelBuilder.Entity<Contact>()
            .Property(x => x.IdTypeContactPk)
            .IsRequired()
            .HasColumnName("id_TypeContact_Pk");

        modelBuilder.Entity<Contact>()
            .Property(x => x.IdCategoryContactPk)
            .IsRequired()
            .HasColumnName("id_CategoryContact_Pk");


        modelBuilder.Entity<Contact>()
            .HasOne(x => x.Person)
            .WithMany(x => x.Contacts)
            .HasForeignKey(x => x.IdPersonPk);

        modelBuilder.Entity<Contact>()
            .HasOne(x => x.TypeOfContact)
            .WithMany(x => x.Contacts)
            .HasForeignKey(x => x.IdTypeContactPk);

        modelBuilder.Entity<Contact>()
            .HasOne(x => x.CategoryContact)
            .WithMany(x => x.Contacts)
            .HasForeignKey(x => x.IdCategoryContactPk);

        
        modelBuilder.Entity<AreaPerson>()
            .HasKey(x => new{x.IdPersonPk,x.IdAreaPk});

        modelBuilder.Entity<AreaPerson>()
            .Property(x => x.IdAreaPk)
            .IsRequired()
            .HasColumnName("id_Area_Pk");

        modelBuilder.Entity<AreaPerson>()
            .Property(x => x.IdPersonPk)
            .IsRequired()
            .HasColumnName("id_Person_Pk");

        modelBuilder.Entity<AreaPerson>()
            .HasOne(x => x.Person)
            .WithMany(x => x.AreaPerson)
            .HasForeignKey(x => x.IdPersonPk);

        modelBuilder.Entity<AreaPerson>()
            .HasOne(x => x.Area)
            .WithMany(x => x.AreaPerson)
            .HasForeignKey(x => x.IdAreaPk);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);

    }
}
