using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gb_active_service_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dependencies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Responsibles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsibles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Actives",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsibleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false),
                    Brand = table.Column<string>(type: "VARCHAR(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actives_Dependencies_DependencyId",
                        column: x => x.DependencyId,
                        principalTable: "Dependencies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Actives_Responsibles_ResponsibleId",
                        column: x => x.ResponsibleId,
                        principalTable: "Responsibles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Actives_DependencyId",
                table: "Actives",
                column: "DependencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Actives_ResponsibleId",
                table: "Actives",
                column: "ResponsibleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actives");

            migrationBuilder.DropTable(
                name: "Dependencies");

            migrationBuilder.DropTable(
                name: "Responsibles");
        }
    }
}
