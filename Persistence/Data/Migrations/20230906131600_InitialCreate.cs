using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "area",
                columns: table => new
                {
                    id_Area_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_Area = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_area", x => x.id_Area_Pk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "categoryContact",
                columns: table => new
                {
                    id_CategoryContact_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_CategoryContact = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryContact", x => x.id_CategoryContact_Pk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "contactType",
                columns: table => new
                {
                    id_ContactType_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_ContactType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactType", x => x.id_ContactType_Pk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "documentType",
                columns: table => new
                {
                    id_DocumentType_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_DocumentType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    abbreviation_DocumentType = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documentType", x => x.id_DocumentType_Pk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "levelIncidence",
                columns: table => new
                {
                    id_LevelIncidence_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_LevelIncidence = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_LevelIncidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_levelIncidence", x => x.id_LevelIncidence_Pk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rol",
                columns: table => new
                {
                    idPk = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rol", x => x.idPk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    id_State_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description_State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id_State_Pk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "typeIncidence",
                columns: table => new
                {
                    id_TypeIncidence_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_TypeIncidence = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    description_TypeIncidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typeIncidence", x => x.id_TypeIncidence_Pk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    idPk = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    username = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.idPk);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    id_Place_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_Place = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_Area_Fk = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place", x => x.id_Place_Pk);
                    table.ForeignKey(
                        name: "FK_place_area_id_Area_Fk",
                        column: x => x.id_Area_Fk,
                        principalTable: "area",
                        principalColumn: "id_Area_Pk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id_Person_Pk = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name_Person = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastname_Person = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    address_Person = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_DocumentType_Fk = table.Column<int>(type: "int", nullable: false),
                    id_User_Fk = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id_Person_Pk);
                    table.ForeignKey(
                        name: "FK_person_documentType_id_DocumentType_Fk",
                        column: x => x.id_DocumentType_Fk,
                        principalTable: "documentType",
                        principalColumn: "id_DocumentType_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_person_user_id_User_Fk",
                        column: x => x.id_User_Fk,
                        principalTable: "user",
                        principalColumn: "idPk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "rolUser",
                columns: table => new
                {
                    userIdPk = table.Column<int>(type: "INT", nullable: false),
                    rolIdPk = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolUser", x => new { x.rolIdPk, x.userIdPk });
                    table.ForeignKey(
                        name: "FK_rolUser_rol_rolIdPk",
                        column: x => x.rolIdPk,
                        principalTable: "rol",
                        principalColumn: "idPk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rolUser_user_userIdPk",
                        column: x => x.userIdPk,
                        principalTable: "user",
                        principalColumn: "idPk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AreaPerson",
                columns: table => new
                {
                    id_Area_Pk = table.Column<int>(type: "int", nullable: false),
                    id_Person_Pk = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaPerson", x => new { x.id_Person_Pk, x.id_Area_Pk });
                    table.ForeignKey(
                        name: "FK_AreaPerson_area_id_Area_Pk",
                        column: x => x.id_Area_Pk,
                        principalTable: "area",
                        principalColumn: "id_Area_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaPerson_person_id_Person_Pk",
                        column: x => x.id_Person_Pk,
                        principalTable: "person",
                        principalColumn: "id_Person_Pk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    id_Person_Pk = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_TypeContact_Pk = table.Column<int>(type: "int", nullable: false),
                    id_CategoryContact_Pk = table.Column<int>(type: "int", nullable: false),
                    description_Contact = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => new { x.id_CategoryContact_Pk, x.id_TypeContact_Pk, x.id_Person_Pk });
                    table.ForeignKey(
                        name: "FK_Contact_categoryContact_id_CategoryContact_Pk",
                        column: x => x.id_CategoryContact_Pk,
                        principalTable: "categoryContact",
                        principalColumn: "id_CategoryContact_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_contactType_id_TypeContact_Pk",
                        column: x => x.id_TypeContact_Pk,
                        principalTable: "contactType",
                        principalColumn: "id_ContactType_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_person_id_Person_Pk",
                        column: x => x.id_Person_Pk,
                        principalTable: "person",
                        principalColumn: "id_Person_Pk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "incidence",
                columns: table => new
                {
                    id_Incidence_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description_Incidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_Incidence = table.Column<DateTime>(type: "Date", nullable: false),
                    id_Person_Fk = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_State_Fk = table.Column<int>(type: "int", nullable: false),
                    id_Area_Fk = table.Column<int>(type: "int", nullable: false),
                    id_Place_Fk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_incidence", x => x.id_Incidence_Pk);
                    table.ForeignKey(
                        name: "FK_incidence_area_id_Area_Fk",
                        column: x => x.id_Area_Fk,
                        principalTable: "area",
                        principalColumn: "id_Area_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_person_id_Person_Fk",
                        column: x => x.id_Person_Fk,
                        principalTable: "person",
                        principalColumn: "id_Person_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_place_id_Place_Fk",
                        column: x => x.id_Place_Fk,
                        principalTable: "place",
                        principalColumn: "id_Place_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_incidence_state_id_State_Fk",
                        column: x => x.id_State_Fk,
                        principalTable: "state",
                        principalColumn: "id_State_Pk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "detailIncidence",
                columns: table => new
                {
                    id_DetailIncidence_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    description_DetailIncidence = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_Incidence_Fk = table.Column<int>(type: "int", nullable: false),
                    id_Peripheral_Fk = table.Column<int>(type: "int", nullable: false),
                    id_TypeIncidence_Fk = table.Column<int>(type: "int", nullable: false),
                    id_LevelIncidence_Fk = table.Column<int>(type: "int", nullable: false),
                    IdStateFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailIncidence", x => x.id_DetailIncidence_Pk);
                    table.ForeignKey(
                        name: "FK_detailIncidence_incidence_id_Incidence_Fk",
                        column: x => x.id_Incidence_Fk,
                        principalTable: "incidence",
                        principalColumn: "id_Incidence_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailIncidence_levelIncidence_id_LevelIncidence_Fk",
                        column: x => x.id_LevelIncidence_Fk,
                        principalTable: "levelIncidence",
                        principalColumn: "id_LevelIncidence_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailIncidence_state_IdStateFk",
                        column: x => x.IdStateFk,
                        principalTable: "state",
                        principalColumn: "id_State_Pk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailIncidence_typeIncidence_id_TypeIncidence_Fk",
                        column: x => x.id_TypeIncidence_Fk,
                        principalTable: "typeIncidence",
                        principalColumn: "id_TypeIncidence_Pk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "peripheral",
                columns: table => new
                {
                    id_Peripheral_Pk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name_Peripheral = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_DetailIncidence_Fk = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_peripheral", x => x.id_Peripheral_Pk);
                    table.ForeignKey(
                        name: "FK_peripheral_detailIncidence_id_DetailIncidence_Fk",
                        column: x => x.id_DetailIncidence_Fk,
                        principalTable: "detailIncidence",
                        principalColumn: "id_DetailIncidence_Pk",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AreaPerson_id_Area_Pk",
                table: "AreaPerson",
                column: "id_Area_Pk");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_id_Person_Pk",
                table: "Contact",
                column: "id_Person_Pk");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_id_TypeContact_Pk",
                table: "Contact",
                column: "id_TypeContact_Pk");

            migrationBuilder.CreateIndex(
                name: "IX_detailIncidence_id_Incidence_Fk",
                table: "detailIncidence",
                column: "id_Incidence_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_detailIncidence_id_LevelIncidence_Fk",
                table: "detailIncidence",
                column: "id_LevelIncidence_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_detailIncidence_id_TypeIncidence_Fk",
                table: "detailIncidence",
                column: "id_TypeIncidence_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_detailIncidence_IdStateFk",
                table: "detailIncidence",
                column: "IdStateFk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_id_Area_Fk",
                table: "incidence",
                column: "id_Area_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_id_Person_Fk",
                table: "incidence",
                column: "id_Person_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_id_Place_Fk",
                table: "incidence",
                column: "id_Place_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_incidence_id_State_Fk",
                table: "incidence",
                column: "id_State_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_peripheral_id_DetailIncidence_Fk",
                table: "peripheral",
                column: "id_DetailIncidence_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_person_id_DocumentType_Fk",
                table: "person",
                column: "id_DocumentType_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_person_id_User_Fk",
                table: "person",
                column: "id_User_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_place_id_Area_Fk",
                table: "place",
                column: "id_Area_Fk");

            migrationBuilder.CreateIndex(
                name: "IX_rolUser_userIdPk",
                table: "rolUser",
                column: "userIdPk");

            migrationBuilder.CreateIndex(
                name: "IX_Username_Email",
                table: "user",
                columns: new[] { "username", "email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaPerson");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "peripheral");

            migrationBuilder.DropTable(
                name: "rolUser");

            migrationBuilder.DropTable(
                name: "categoryContact");

            migrationBuilder.DropTable(
                name: "contactType");

            migrationBuilder.DropTable(
                name: "detailIncidence");

            migrationBuilder.DropTable(
                name: "rol");

            migrationBuilder.DropTable(
                name: "incidence");

            migrationBuilder.DropTable(
                name: "levelIncidence");

            migrationBuilder.DropTable(
                name: "typeIncidence");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "place");

            migrationBuilder.DropTable(
                name: "state");

            migrationBuilder.DropTable(
                name: "documentType");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "area");
        }
    }
}
