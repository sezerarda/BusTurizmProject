using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class VehicleInsLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "Varchar(50)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "Varchar(50)", nullable: true),
                    Cinsiyet = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "Varchar(20)", nullable: false),
                    VehicleDefinitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_VehicleDefinition_VehicleDefinitionId",
                        column: x => x.VehicleDefinitionId,
                        principalTable: "VehicleDefinition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleRoute",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleRoute_City_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleRoute_City_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleRouteId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusTrip_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTrip_VehicleRoute_VehicleRouteId",
                        column: x => x.VehicleRouteId,
                        principalTable: "VehicleRoute",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusTripId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_BusTrip_BusTripId",
                        column: x => x.BusTripId,
                        principalTable: "BusTrip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 7, "Ankara" },
                    { 8, "Antalya" },
                    { 21, "Bursa" },
                    { 40, "İstanbul" },
                    { 41, "İzmir" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "Cinsiyet", "IdentityNumber", "Name", "Surname" },
                values: new object[] { 1, 2, "1234566", "Mustafa", "Korkmaz" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "PlateNumber", "VehicleDefinitionId" },
                values: new object[,]
                {
                    { 1, "34 DF 312", 1 },
                    { 2, "16 CG 777", 1 },
                    { 3, "06 AB 312", 2 },
                    { 4, "34 AG 312", 3 },
                    { 5, "37 GF 312", 3 },
                    { 6, "58 DD 312", 1 }
                });

            migrationBuilder.InsertData(
                table: "VehicleRoute",
                columns: new[] { "Id", "ArrivalCityId", "DepartureCityId", "Description" },
                values: new object[] { 1, 40, 41, "Açıklama 1" });

            migrationBuilder.InsertData(
                table: "VehicleRoute",
                columns: new[] { "Id", "ArrivalCityId", "DepartureCityId", "Description" },
                values: new object[] { 2, 8, 40, "Açıklama 2" });

            migrationBuilder.InsertData(
                table: "VehicleRoute",
                columns: new[] { "Id", "ArrivalCityId", "DepartureCityId", "Description" },
                values: new object[] { 3, 8, 7, "Açıklama 3" });

            migrationBuilder.InsertData(
                table: "BusTrip",
                columns: new[] { "Id", "Date", "Price", "VehicleId", "VehicleRouteId" },
                values: new object[] { 1, new DateTime(2023, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 100m, 1, 1 });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "BusTripId", "CustomerId", "Price", "SeatNumber" },
                values: new object[] { 1, 1, 1, 200m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_VehicleId",
                table: "BusTrip",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_VehicleRouteId",
                table: "BusTrip",
                column: "VehicleRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BusTripId",
                table: "Ticket",
                column: "BusTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleDefinitionId",
                table: "Vehicle",
                column: "VehicleDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRoute_ArrivalCityId",
                table: "VehicleRoute",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleRoute_DepartureCityId",
                table: "VehicleRoute",
                column: "DepartureCityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "BusTrip");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleRoute");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
