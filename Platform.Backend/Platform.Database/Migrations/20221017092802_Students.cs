using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platform.Database.Migrations
{
    public partial class Students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8417836b-e218-4f36-96fe-6bc9932d0601");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "54e356f0-550b-4acf-a8b7-7dc419b0159f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5d16c248-712c-4d03-9b56-50d7b23d7e3e", "AQAAAAEAACcQAAAAEIScS12FfiRbsIilSztDuFfTs1gGmyE27O0FwJHoZ7hSDWmt0KJncClf89VaU/blGw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SelectionId", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, new DateTime(1974, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "e4527724-3e30-444d-a014-805f5002909c", "Student", null, false, "Rasheed", "Wallace", false, null, null, null, "AQAAAAEAACcQAAAAEORdPdguQhQWv5GSM+g3GPdGY+TTgTewqCSynPef/qbf8DZ1/7uFW4MGj305ZxCDsw==", null, false, null, new Guid("4c2b95e0-2022-4a8f-b537-eb3a32786b06"), 1, false, "sheed" },
                    { 3, 0, new DateTime(1976, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "c01e3b43-146c-4509-a12f-34ce489683ed", "Student", null, false, "Allen", "Iverson", false, null, null, null, "AQAAAAEAACcQAAAAEKyzWwV53RkysPBF5uB79y6RdLUDz1K/YFQrPZ3cl5xrZim3w2MtMQ9h96/tA06K2Q==", null, false, null, new Guid("a1066e97-c7c8-4aee-905b-61bb31d82bfb"), 2, false, "answer" },
                    { 4, 0, new DateTime(1975, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "e70fd0bf-2fef-43e8-8f5f-a61e0a8b50b4", "Student", null, false, "Vince", "Carter", false, null, null, null, "AQAAAAEAACcQAAAAEOKsjC1byRokPI5f4Mwi3nZ65OA4yRXca6sCKXf9/dLL5PtfJ2aZFUs+0nKZ0WmyQw==", null, false, null, new Guid("a1066e97-c7c8-4aee-905b-61bb31d82bfb"), 1, false, "vinsanity" },
                    { 5, 0, new DateTime(1978, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "15ea3d6e-9a87-4449-b245-e07c018fc5a4", "Student", null, false, "Gary", "Payton", false, null, null, null, "AQAAAAEAACcQAAAAEAeI3v1Z/d8vkQy6wjCbqFh/vZkRvbm8gADWoQciWXzytxFF5q8+nGpQHyFOP0zJrg==", null, false, null, new Guid("30f96ef9-7b45-42f7-9fab-05a70e7fc394"), 0, false, "glove" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8bc5e73f-792d-4977-aa7d-0c11bd448430");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "78130c1f-c91e-4379-9f3a-dd1d70a179cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "68f9969e-9531-4231-a3be-1c091fa5b3ea", "AQAAAAEAACcQAAAAEDdSCInWuy2xZ70sh69q2569p7OwJrsWGGQtGzYFz6X4mGkc2dKsR2l2PC88kbalIw==" });
        }
    }
}
