using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicEsatateWebApi.Migrations
{
    /// <inheritdoc />
    public partial class AddEstateNumberToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstateNumbers",
                columns: table => new
                {
                    EstateNo = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateNumbers", x => x.EstateNo);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateNumbers");

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
    }
}
