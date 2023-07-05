using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class NewCityRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[] { 22, "Çanakkale" });

            migrationBuilder.InsertData(
                table: "VehicleRoute",
                columns: new[] { "Id", "ArrivalCityId", "DepartureCityId", "Description" },
                values: new object[] { 4, 22, 21, "Açıklama 4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleRoute",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 22);
        }
    }
}
