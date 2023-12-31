﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Area", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_Area_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_Area");

                    b.HasKey("IdPk");

                    b.ToTable("area", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AreaPerson", b =>
                {
                    b.Property<string>("IdPersonPk")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id_Person_Pk");

                    b.Property<int>("IdAreaPk")
                        .HasColumnType("int")
                        .HasColumnName("id_Area_Pk");

                    b.HasKey("IdPersonPk", "IdAreaPk");

                    b.HasIndex("IdAreaPk");

                    b.ToTable("AreaPerson");
                });

            modelBuilder.Entity("Domain.Entities.CategoryContact", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_CategoryContact_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_CategoryContact");

                    b.HasKey("IdPk");

                    b.ToTable("categoryContact", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Contact", b =>
                {
                    b.Property<int>("IdCategoryContactPk")
                        .HasColumnType("int")
                        .HasColumnName("id_CategoryContact_Pk");

                    b.Property<int>("IdTypeContactPk")
                        .HasColumnType("int")
                        .HasColumnName("id_TypeContact_Pk");

                    b.Property<string>("IdPersonPk")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id_Person_Pk");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("description_Contact");

                    b.HasKey("IdCategoryContactPk", "IdTypeContactPk", "IdPersonPk");

                    b.HasIndex("IdPersonPk");

                    b.HasIndex("IdTypeContactPk");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Domain.Entities.ContactType", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_ContactType_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name_ContactType");

                    b.HasKey("IdPk");

                    b.ToTable("contactType", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DetailIncidence", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_DetailIncidence_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description_DetailIncidence");

                    b.Property<int>("IdIncidenceFk")
                        .HasColumnType("int")
                        .HasColumnName("id_Incidence_Fk");

                    b.Property<int>("IdLevelIncidenceFk")
                        .HasColumnType("int")
                        .HasColumnName("id_LevelIncidence_Fk");

                    b.Property<int>("IdPeripheralFk")
                        .HasColumnType("int")
                        .HasColumnName("id_Peripheral_Fk");

                    b.Property<int>("IdStateFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeIncidenceFk")
                        .HasColumnType("int")
                        .HasColumnName("id_TypeIncidence_Fk");

                    b.HasKey("IdPk");

                    b.HasIndex("IdIncidenceFk");

                    b.HasIndex("IdLevelIncidenceFk");

                    b.HasIndex("IdStateFk");

                    b.HasIndex("IdTypeIncidenceFk");

                    b.ToTable("detailIncidence", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DocumentType", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_DocumentType_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("abbreviation_DocumentType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_DocumentType");

                    b.HasKey("IdPk");

                    b.ToTable("documentType", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Incidence", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_Incidence_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date")
                        .HasColumnName("date_Incidence");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description_Incidence");

                    b.Property<string>("Detail")
                        .HasColumnType("longtext");

                    b.Property<int>("IdAreaFk")
                        .HasColumnType("int")
                        .HasColumnName("id_Area_Fk");

                    b.Property<string>("IdPersonFk")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id_Person_Fk");

                    b.Property<int>("IdPlaceFk")
                        .HasColumnType("int")
                        .HasColumnName("id_Place_Fk");

                    b.Property<int>("IdStateFk")
                        .HasColumnType("int")
                        .HasColumnName("id_State_Fk");

                    b.HasKey("IdPk");

                    b.HasIndex("IdAreaFk");

                    b.HasIndex("IdPersonFk");

                    b.HasIndex("IdPlaceFk");

                    b.HasIndex("IdStateFk");

                    b.ToTable("incidence", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.LevelIncidence", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_LevelIncidence_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description_LevelIncidence");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_LevelIncidence");

                    b.HasKey("IdPk");

                    b.ToTable("levelIncidence", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Peripheral", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_Peripheral_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDetailIncidenceFk")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("id_DetailIncidence_Fk");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_Peripheral");

                    b.HasKey("IdPk");

                    b.HasIndex("IdDetailIncidenceFk");

                    b.ToTable("peripheral", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Property<string>("IdPk")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("id_Person_Pk");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address_Person");

                    b.Property<int>("IdDocumentTypeFk")
                        .HasColumnType("int")
                        .HasColumnName("id_DocumentType_Fk");

                    b.Property<int>("IdUserFk")
                        .HasColumnType("int")
                        .HasColumnName("id_User_Fk");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("lastname_Person");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_Person");

                    b.HasKey("IdPk");

                    b.HasIndex("IdDocumentTypeFk");

                    b.HasIndex("IdUserFk");

                    b.ToTable("person", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Place", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_Place_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IdAreaFk")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("id_Area_Fk");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_Place");

                    b.HasKey("IdPk");

                    b.HasIndex("IdAreaFk");

                    b.ToTable("place", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasColumnName("idPk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.HasKey("IdPk");

                    b.ToTable("rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RolUser", b =>
                {
                    b.Property<int>("RolIdPk")
                        .HasColumnType("INT")
                        .HasColumnName("rolIdPk");

                    b.Property<int>("UserIdPk")
                        .HasColumnType("INT")
                        .HasColumnName("userIdPk");

                    b.HasKey("RolIdPk", "UserIdPk");

                    b.HasIndex("UserIdPk");

                    b.ToTable("rolUser", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_State_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description_State");

                    b.HasKey("IdPk");

                    b.ToTable("state", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.TypeIncidence", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_TypeIncidence_Pk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description_TypeIncidence");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name_TypeIncidence");

                    b.HasKey("IdPk");

                    b.ToTable("typeIncidence", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("IdPk")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPk")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password");

                    b.Property<string>("Usename")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("IdPk");

                    b.HasIndex("Usename", "Email")
                        .IsUnique()
                        .HasDatabaseName("IX_Username_Email");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.AreaPerson", b =>
                {
                    b.HasOne("Domain.Entities.Area", "Area")
                        .WithMany("AreaPerson")
                        .HasForeignKey("IdAreaPk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("AreaPerson")
                        .HasForeignKey("IdPersonPk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.Contact", b =>
                {
                    b.HasOne("Domain.Entities.CategoryContact", "CategoryContact")
                        .WithMany("Contacts")
                        .HasForeignKey("IdCategoryContactPk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("Contacts")
                        .HasForeignKey("IdPersonPk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.ContactType", "TypeOfContact")
                        .WithMany("Contacts")
                        .HasForeignKey("IdTypeContactPk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoryContact");

                    b.Navigation("Person");

                    b.Navigation("TypeOfContact");
                });

            modelBuilder.Entity("Domain.Entities.DetailIncidence", b =>
                {
                    b.HasOne("Domain.Entities.Incidence", "Incidence")
                        .WithMany("DetailIncidences")
                        .HasForeignKey("IdIncidenceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.LevelIncidence", "LevelOfIncidence")
                        .WithMany("DetailIncidences")
                        .HasForeignKey("IdLevelIncidenceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.State", "State")
                        .WithMany("DetailIncidences")
                        .HasForeignKey("IdStateFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.TypeIncidence", "TypeIncidence")
                        .WithMany("DetailIncidences")
                        .HasForeignKey("IdTypeIncidenceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incidence");

                    b.Navigation("LevelOfIncidence");

                    b.Navigation("State");

                    b.Navigation("TypeIncidence");
                });

            modelBuilder.Entity("Domain.Entities.Incidence", b =>
                {
                    b.HasOne("Domain.Entities.Area", "Areas")
                        .WithMany("Incidences")
                        .HasForeignKey("IdAreaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Person", "Person")
                        .WithMany("Incidences")
                        .HasForeignKey("IdPersonFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Place", "Place")
                        .WithMany("Incidences")
                        .HasForeignKey("IdPlaceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.State", "States")
                        .WithMany("Incidences")
                        .HasForeignKey("IdStateFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Areas");

                    b.Navigation("Person");

                    b.Navigation("Place");

                    b.Navigation("States");
                });

            modelBuilder.Entity("Domain.Entities.Peripheral", b =>
                {
                    b.HasOne("Domain.Entities.DetailIncidence", "DetailIncidence")
                        .WithMany("Peripherals")
                        .HasForeignKey("IdDetailIncidenceFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailIncidence");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.HasOne("Domain.Entities.DocumentType", "DocumentType")
                        .WithMany("Person")
                        .HasForeignKey("IdDocumentTypeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("Person")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DocumentType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Place", b =>
                {
                    b.HasOne("Domain.Entities.Area", "Area")
                        .WithMany("Places")
                        .HasForeignKey("IdAreaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("Domain.Entities.RolUser", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("RolUsers")
                        .HasForeignKey("RolIdPk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "User")
                        .WithMany("RolUsers")
                        .HasForeignKey("UserIdPk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Domain.Entities.Area", b =>
                {
                    b.Navigation("AreaPerson");

                    b.Navigation("Incidences");

                    b.Navigation("Places");
                });

            modelBuilder.Entity("Domain.Entities.CategoryContact", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Domain.Entities.ContactType", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("Domain.Entities.DetailIncidence", b =>
                {
                    b.Navigation("Peripherals");
                });

            modelBuilder.Entity("Domain.Entities.DocumentType", b =>
                {
                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domain.Entities.Incidence", b =>
                {
                    b.Navigation("DetailIncidences");
                });

            modelBuilder.Entity("Domain.Entities.LevelIncidence", b =>
                {
                    b.Navigation("DetailIncidences");
                });

            modelBuilder.Entity("Domain.Entities.Person", b =>
                {
                    b.Navigation("AreaPerson");

                    b.Navigation("Contacts");

                    b.Navigation("Incidences");
                });

            modelBuilder.Entity("Domain.Entities.Place", b =>
                {
                    b.Navigation("Incidences");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("RolUsers");
                });

            modelBuilder.Entity("Domain.Entities.State", b =>
                {
                    b.Navigation("DetailIncidences");

                    b.Navigation("Incidences");
                });

            modelBuilder.Entity("Domain.Entities.TypeIncidence", b =>
                {
                    b.Navigation("DetailIncidences");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("Person");

                    b.Navigation("RolUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
