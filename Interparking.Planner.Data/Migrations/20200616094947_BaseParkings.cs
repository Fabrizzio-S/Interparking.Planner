using Microsoft.EntityFrameworkCore.Migrations;

namespace Interparking.Planner.Data.Migrations
{
    public partial class BaseParkings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Address", "Description", "DisabledSpaces", "Latitude", "Longitude", "MaxHeight", "Name", "Spaces" },
                values: new object[] { 1, "bvd de Waterloo 2a, 1000 Bruxelles", "Le parking se situe en plein cœur d'un quartier commercial et du cinéma UGC Toison d'Or.", 32, "50.838497", "4.361148", 2.1m, "2 Portes (Bruxelles)", 719 });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Address", "Description", "DisabledSpaces", "Latitude", "Longitude", "MaxHeight", "Name", "Spaces" },
                values: new object[] { 2, "Place de la Justice 16, 1000 Bruxelles", "Le parking se situe sous le Square, lieu d'évènements innombrables. Il est également à deux pas du Palais des Beaux Arts, du Musée Magritte et du Musée des Instruments de Musique.", 15, "50.843919", "4.354608", 2m, "Albertine-Square (Bruxelles)", 714 });

            migrationBuilder.InsertData(
                table: "Parkings",
                columns: new[] { "Id", "Address", "Description", "DisabledSpaces", "Latitude", "Longitude", "MaxHeight", "Name", "Spaces" },
                values: new object[] { 3, "Brussels Airport, 1930 Zaventem", @"Le parking se trouve en face du terminal de départ de Brussels Airport.

Parfait pour l'homme d'affaires qui arrive juste à temps pour le check in.

Pour y accéder, entrez dans le parking P1 Front et suivez les indications Fast Zone.", 3, "50.897399", "4.481088", 2.1m, "P1 Fast Zone level 3 (Zaventem)", 166 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parkings",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
