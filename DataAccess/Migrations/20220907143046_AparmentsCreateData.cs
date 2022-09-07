using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AparmentsCreateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "BlockName", "NumberOfFloors", "NumberOfHousesOnTheFloors" },
                values: new object[,]
                {
                    { 1, "A Block", 10, 3 },
                    { 2, "B Block", 10, 3 },
                    { 3, "C Block", 10, 3 },
                    { 4, "D Block", 10, 3 },
                    { 5, "E Block", 10, 3 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 119, 191, 255, 165, 188, 192, 219, 44, 118, 177, 56, 74, 137, 126, 20, 15, 14, 150, 113, 140, 215, 156, 107, 116, 201, 154, 5, 185, 198, 199, 131, 59, 104, 206, 157, 168, 95, 107, 214, 243, 162, 29, 235, 73, 249, 45, 245, 234, 202, 137, 117, 87, 12, 208, 58, 2, 16, 18, 74, 71, 32, 15, 121, 158 }, new byte[] { 70, 247, 33, 62, 164, 242, 157, 20, 32, 25, 251, 159, 246, 87, 179, 123, 152, 27, 26, 186, 231, 157, 201, 68, 47, 226, 186, 142, 146, 213, 88, 64, 14, 231, 80, 88, 40, 8, 113, 139, 75, 66, 0, 81, 102, 112, 226, 144, 183, 179, 19, 84, 184, 45, 13, 123, 29, 131, 204, 156, 63, 169, 222, 71, 208, 45, 28, 209, 226, 9, 214, 60, 189, 75, 83, 0, 27, 108, 198, 204, 73, 203, 254, 82, 123, 142, 118, 122, 221, 165, 159, 174, 17, 75, 160, 130, 112, 204, 101, 233, 70, 25, 166, 20, 169, 203, 144, 196, 221, 94, 200, 226, 14, 219, 197, 35, 229, 191, 72, 43, 157, 230, 242, 203, 169, 2, 86, 241 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 97, 72, 236, 21, 70, 236, 228, 36, 40, 227, 37, 6, 245, 202, 208, 2, 201, 235, 160, 57, 8, 177, 157, 254, 53, 196, 250, 7, 37, 46, 154, 215, 197, 165, 105, 62, 131, 56, 10, 29, 50, 52, 159, 145, 22, 47, 150, 91, 40, 152, 104, 125, 159, 74, 91, 58, 236, 92, 234, 23, 77, 173, 91, 157 }, new byte[] { 48, 230, 222, 154, 121, 211, 157, 134, 225, 13, 234, 82, 84, 157, 121, 232, 74, 50, 254, 24, 250, 105, 42, 242, 224, 127, 15, 237, 154, 32, 190, 162, 78, 26, 31, 212, 203, 185, 129, 254, 121, 16, 161, 164, 121, 79, 2, 221, 203, 72, 196, 121, 50, 62, 210, 24, 212, 54, 230, 20, 106, 189, 76, 72, 6, 168, 149, 79, 151, 106, 79, 162, 27, 109, 235, 221, 4, 237, 236, 161, 124, 255, 194, 40, 253, 94, 252, 254, 10, 210, 125, 92, 108, 76, 36, 151, 217, 127, 184, 50, 117, 195, 46, 252, 69, 225, 178, 223, 201, 159, 184, 120, 113, 206, 47, 244, 142, 183, 224, 208, 138, 79, 208, 91, 167, 100, 25, 170 } });
        }
    }
}
