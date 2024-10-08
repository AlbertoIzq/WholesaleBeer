using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WholesaleBeer.API.Migrations
{
    /// <inheritdoc />
    public partial class seedBeerAndBeerStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "Id", "AlcoholContentPercentage", "BreweryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("527fad60-6791-41d7-aadb-439805a5957b"), 9.0, new Guid("36a69969-2a36-4f96-b037-b5603fe94a78"), "Chimay Bleu", 3.6000000000000001 },
                    { new Guid("5b71078e-3e4e-495c-c75b-08dce2d581f8"), 10.199999999999999, new Guid("53965366-20b3-4f2d-9972-a886d6972c1f"), "Trappist Westvleteren 12", 2.3300000000000001 },
                    { new Guid("6e3b4a15-ae20-40a1-114a-08dce2d288ad"), 11.300000000000001, new Guid("91d8c67c-c92b-48a4-95b3-77182bfcbf73"), "Rochefort 10", 4.0999999999999996 },
                    { new Guid("7503faeb-f43c-428a-c75c-08dce2d581f8"), 8.0, new Guid("53965366-20b3-4f2d-9972-a886d6972c1f"), "Trappist Westvleteren 8", 2.04 },
                    { new Guid("771f94ac-9bd6-4c82-2457-08dce27be8ae"), 6.2000000000000002, new Guid("8db2bb14-5ae6-4894-9aab-205d29bfb176"), "Orval", 3.7000000000000002 },
                    { new Guid("7aefcee4-347f-4184-114b-08dce2d288ad"), 9.1999999999999993, new Guid("91d8c67c-c92b-48a4-95b3-77182bfcbf73"), "Rochefort 8", 3.0499999999999998 },
                    { new Guid("b333123a-b777-41bc-a457-d6b28c2acb91"), 9.5, new Guid("62410140-4fb9-4662-8ef6-b5aa9dd7aa5d"), "Westmalle Tripel", 2.6899999999999999 }
                });

            migrationBuilder.InsertData(
                table: "BeerStocks",
                columns: new[] { "Id", "BeerId", "StockLeft", "WholesalerId" },
                values: new object[,]
                {
                    { new Guid("0d646172-29dd-41f8-aa1e-8483980cb9ef"), new Guid("771f94ac-9bd6-4c82-2457-08dce27be8ae"), 150, new Guid("9fc5f185-c6c3-4bcd-90c0-74e35304d69c") },
                    { new Guid("13e5a2f2-cf06-4cd7-83e2-03cd681878ef"), new Guid("7aefcee4-347f-4184-114b-08dce2d288ad"), 15, new Guid("5c8e5f49-652b-42b0-8418-cd5a0ddba3fd") },
                    { new Guid("677d69a7-1c81-4b19-b178-8a473390e96a"), new Guid("6e3b4a15-ae20-40a1-114a-08dce2d288ad"), 80, new Guid("9fc5f185-c6c3-4bcd-90c0-74e35304d69c") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BeerStocks",
                keyColumn: "Id",
                keyValue: new Guid("0d646172-29dd-41f8-aa1e-8483980cb9ef"));

            migrationBuilder.DeleteData(
                table: "BeerStocks",
                keyColumn: "Id",
                keyValue: new Guid("13e5a2f2-cf06-4cd7-83e2-03cd681878ef"));

            migrationBuilder.DeleteData(
                table: "BeerStocks",
                keyColumn: "Id",
                keyValue: new Guid("677d69a7-1c81-4b19-b178-8a473390e96a"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("527fad60-6791-41d7-aadb-439805a5957b"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("5b71078e-3e4e-495c-c75b-08dce2d581f8"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("7503faeb-f43c-428a-c75c-08dce2d581f8"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("b333123a-b777-41bc-a457-d6b28c2acb91"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("6e3b4a15-ae20-40a1-114a-08dce2d288ad"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("771f94ac-9bd6-4c82-2457-08dce27be8ae"));

            migrationBuilder.DeleteData(
                table: "Beers",
                keyColumn: "Id",
                keyValue: new Guid("7aefcee4-347f-4184-114b-08dce2d288ad"));
        }
    }
}
