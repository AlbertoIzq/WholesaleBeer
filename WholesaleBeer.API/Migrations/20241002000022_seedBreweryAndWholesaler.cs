using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleBeer.API.Migrations
{
    /// <inheritdoc />
    public partial class seedBreweryAndWholesaler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Breweries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("36a69969-2a36-4f96-b037-b5603fe94a78"), "Abbaye de Notre Dame de Scourmont" },
                    { new Guid("53965366-20b3-4f2d-9972-a886d6972c1f"), "Abbaye St Sixte Westvleteren" },
                    { new Guid("62410140-4fb9-4662-8ef6-b5aa9dd7aa5d"), "Abbaye Notre Dame du Sacre Coeur de Westmalle" },
                    { new Guid("8db2bb14-5ae6-4894-9aab-205d29bfb176"), "Abbaye d'Orval" },
                    { new Guid("91d8c67c-c92b-48a4-95b3-77182bfcbf73"), "Abbaye Notre Dame de St Remy" }
                });

            migrationBuilder.InsertData(
                table: "Wholesalers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ffec24c-e643-410d-aafb-e0cefa0934b1"), "Drink Services - Brasserie Corman" },
                    { new Guid("34acf5ff-19c2-477c-8a5b-b89b479002ce"), "Drinks Center Fontana" },
                    { new Guid("57ed2087-b816-4dcd-a3f1-3451822bb545"), "Bierhandel Dekoninck" },
                    { new Guid("5c8e5f49-652b-42b0-8418-cd5a0ddba3fd"), "Bollaert Wijnhuis" },
                    { new Guid("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"), "Belgibeer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("36a69969-2a36-4f96-b037-b5603fe94a78"));

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("53965366-20b3-4f2d-9972-a886d6972c1f"));

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("62410140-4fb9-4662-8ef6-b5aa9dd7aa5d"));

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("8db2bb14-5ae6-4894-9aab-205d29bfb176"));

            migrationBuilder.DeleteData(
                table: "Breweries",
                keyColumn: "Id",
                keyValue: new Guid("91d8c67c-c92b-48a4-95b3-77182bfcbf73"));

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: new Guid("0ffec24c-e643-410d-aafb-e0cefa0934b1"));

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: new Guid("34acf5ff-19c2-477c-8a5b-b89b479002ce"));

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: new Guid("57ed2087-b816-4dcd-a3f1-3451822bb545"));

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: new Guid("5c8e5f49-652b-42b0-8418-cd5a0ddba3fd"));

            migrationBuilder.DeleteData(
                table: "Wholesalers",
                keyColumn: "Id",
                keyValue: new Guid("9fc5f185-c6c3-4bcd-90c0-74e35304d69c"));
        }
    }
}
