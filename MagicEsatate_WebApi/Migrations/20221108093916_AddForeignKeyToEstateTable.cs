using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEsatateWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToEstateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstateID",
                table: "EstateNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 8, 10, 39, 16, 723, DateTimeKind.Local).AddTicks(5736));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 8, 10, 39, 16, 723, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 8, 10, 39, 16, 723, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 8, 10, 39, 16, 723, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 8, 10, 39, 16, 723, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.CreateIndex(
                name: "IX_EstateNumbers_EstateID",
                table: "EstateNumbers",
                column: "EstateID");

            migrationBuilder.AddForeignKey(
                name: "FK_EstateNumbers_Estates_EstateID",
                table: "EstateNumbers",
                column: "EstateID",
                principalTable: "Estates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EstateNumbers_Estates_EstateID",
                table: "EstateNumbers");

            migrationBuilder.DropIndex(
                name: "IX_EstateNumbers_EstateID",
                table: "EstateNumbers");

            migrationBuilder.DropColumn(
                name: "EstateID",
                table: "EstateNumbers");

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 19, 59, 28, 466, DateTimeKind.Local).AddTicks(3936));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 19, 59, 28, 466, DateTimeKind.Local).AddTicks(3954));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 19, 59, 28, 466, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 19, 59, 28, 466, DateTimeKind.Local).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "Estates",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2022, 11, 7, 19, 59, 28, 466, DateTimeKind.Local).AddTicks(3959));
        }
    }
}
