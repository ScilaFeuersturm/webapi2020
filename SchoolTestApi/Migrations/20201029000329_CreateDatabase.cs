using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace SchoolTestApi.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadquarterItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadquarterItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Subtitle = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeachersItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Headquarter = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmergencyContactName = table.Column<string>(nullable: true),
                    EmergencyContactNumber = table.Column<string>(nullable: true),
                    HeadquarterEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeachersItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeachersItems_HeadquarterItems_HeadquarterEntityId",
                        column: x => x.HeadquarterEntityId,
                        principalTable: "HeadquarterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Headquarter = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmergencyContactName = table.Column<string>(nullable: true),
                    EmergencyContactNumber = table.Column<string>(nullable: true),
                    TeacherEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentItems_TeachersItems_TeacherEntityId",
                        column: x => x.TeacherEntityId,
                        principalTable: "TeachersItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentItems_TeacherEntityId",
                table: "StudentItems",
                column: "TeacherEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeachersItems_HeadquarterEntityId",
                table: "TeachersItems",
                column: "HeadquarterEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactItems");

            migrationBuilder.DropTable(
                name: "NewsItems");

            migrationBuilder.DropTable(
                name: "StudentItems");

            migrationBuilder.DropTable(
                name: "TeachersItems");

            migrationBuilder.DropTable(
                name: "HeadquarterItems");
        }
    }
}
