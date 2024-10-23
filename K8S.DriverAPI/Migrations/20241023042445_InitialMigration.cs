using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace K8S.DriverAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverNumber = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "AddedDate", "DateOfBirth", "DriverNumber", "FirstName", "LastName", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("2533a92b-16ae-4a4f-ab9d-9a2a1c229a0a"), new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4410), new DateTime(1985, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, "Lewis", "Hamilton", 1, new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4415) },
                    { new Guid("86a3df6c-cf33-48f9-9f39-7ea8d0c6c8b6"), new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4425), new DateTime(1997, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Charles", "Leclerc", 1, new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4425) },
                    { new Guid("bae4eb9d-6347-4e11-b886-f2880b65797e"), new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4423), new DateTime(1997, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, "Max", "Verstappen", 1, new DateTime(2024, 10, 23, 4, 24, 44, 813, DateTimeKind.Utc).AddTicks(4423) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drivers");
        }
    }
}
