using Microsoft.EntityFrameworkCore.Migrations;

namespace Interparking.Planner.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parkings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Spaces = table.Column<int>(nullable: false),
                    DisabledSpaces = table.Column<int>(nullable: false),
                    MaxHeight = table.Column<decimal>(nullable: false),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parkings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    StartPointId = table.Column<int>(nullable: true),
                    EndPointId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    RouteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Point_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Point_RouteId",
                table: "Point",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_EndPointId",
                table: "Routes",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_StartPointId",
                table: "Routes",
                column: "StartPointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Point_EndPointId",
                table: "Routes",
                column: "EndPointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Point_StartPointId",
                table: "Routes",
                column: "StartPointId",
                principalTable: "Point",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Point_Routes_RouteId",
                table: "Point");

            migrationBuilder.DropTable(
                name: "Parkings");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Point");
        }
    }
}
