using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumberOfFloors = table.Column<int>(type: "integer", nullable: false),
                    NumberOfHousesOnTheFloors = table.Column<int>(type: "integer", nullable: false),
                    BlockName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ApartmentId = table.Column<int>(type: "integer", nullable: false),
                    TypeInfo = table.Column<string>(type: "text", nullable: true),
                    FloorNumber = table.Column<int>(type: "integer", nullable: false),
                    DoorNumber = table.Column<int>(type: "integer", nullable: false),
                    IsOwner = table.Column<bool>(type: "boolean", nullable: false),
                    State = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    NationalyId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    OperationClaimId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvocingDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastPaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    InvoiceGenreId = table.Column<int>(type: "integer", nullable: false),
                    HouseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceGenres_InvoiceGenreId",
                        column: x => x.InvoiceGenreId,
                        principalTable: "InvoiceGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "NationalyId", "PhoneNumber" },
                values: new object[] { 1, "admin@admin.com", "Admin", "manager", "00000000000", "02122323232" });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "OperationClaimId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, new byte[] { 97, 72, 236, 21, 70, 236, 228, 36, 40, 227, 37, 6, 245, 202, 208, 2, 201, 235, 160, 57, 8, 177, 157, 254, 53, 196, 250, 7, 37, 46, 154, 215, 197, 165, 105, 62, 131, 56, 10, 29, 50, 52, 159, 145, 22, 47, 150, 91, 40, 152, 104, 125, 159, 74, 91, 58, 236, 92, 234, 23, 77, 173, 91, 157 }, new byte[] { 48, 230, 222, 154, 121, 211, 157, 134, 225, 13, 234, 82, 84, 157, 121, 232, 74, 50, 254, 24, 250, 105, 42, 242, 224, 127, 15, 237, 154, 32, 190, 162, 78, 26, 31, 212, 203, 185, 129, 254, 121, 16, 161, 164, 121, 79, 2, 221, 203, 72, 196, 121, 50, 62, 210, 24, 212, 54, 230, 20, 106, 189, 76, 72, 6, 168, 149, 79, 151, 106, 79, 162, 27, 109, 235, 221, 4, 237, 236, 161, 124, 255, 194, 40, 253, 94, 252, 254, 10, 210, 125, 92, 108, 76, 36, 151, 217, 127, 184, 50, 117, 195, 46, 252, 69, 225, 178, 223, 201, 159, 184, 120, 113, 206, 47, 244, 142, 183, 224, 208, 138, 79, 208, 91, 167, 100, 25, 170 } });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_HouseId",
                table: "Invoices",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceGenreId",
                table: "Invoices",
                column: "InvoiceGenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "InvoiceGenres");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
