using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEsatateWebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedEstateTableWithCreateDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 17, 15, 2, 695, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 17, 15, 2, 695, DateTimeKind.Local).AddTicks(1107));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 17, 15, 2, 695, DateTimeKind.Local).AddTicks(1109));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 17, 15, 2, 695, DateTimeKind.Local).AddTicks(1110));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 5, 17, 15, 2, 695, DateTimeKind.Local).AddTicks(1112));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
