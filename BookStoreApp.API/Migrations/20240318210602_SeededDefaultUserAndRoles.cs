using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUserAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86c67d25-97c3-4ccf-b229-e7ac084f2268", null, "User", "USER" },
                    { "cb0c558c-89c5-4f1a-bfbf-32dff3c2990a", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8175218f-81db-44df-8580-07e8ac1e62df", 0, "5a96cbef-cb83-4862-809d-fc9dcd7d06b9", "user@bookstore.com", false, "System", "User", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEOhgaKnxNsFVDLHrSUCO5CDU45jMXQf4sdFU7CPY1F5KZnXtqsVDn7y/LNXQ20AQWQ==", null, false, "02df0408-a93c-40ba-ae20-be62c81697ae", false, "user@bookstore.com" },
                    { "d91ae632-e1a2-4cdd-a84e-97572a377f1d", 0, "5cba8399-7b60-46cd-8038-3444dfb7979c", "admin@bookstore.com", false, "System", "Admin", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEGvf22MRNC7gOsWemmBFgpvtd7GcSjlxJIugXdfaBtzbqD3g0+z7N9k5ki5Kp6WOIg==", null, false, "9d500263-fdb2-4912-8266-6c86b0039eea", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "86c67d25-97c3-4ccf-b229-e7ac084f2268", "8175218f-81db-44df-8580-07e8ac1e62df" },
                    { "cb0c558c-89c5-4f1a-bfbf-32dff3c2990a", "d91ae632-e1a2-4cdd-a84e-97572a377f1d" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "86c67d25-97c3-4ccf-b229-e7ac084f2268", "8175218f-81db-44df-8580-07e8ac1e62df" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cb0c558c-89c5-4f1a-bfbf-32dff3c2990a", "d91ae632-e1a2-4cdd-a84e-97572a377f1d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86c67d25-97c3-4ccf-b229-e7ac084f2268");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb0c558c-89c5-4f1a-bfbf-32dff3c2990a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8175218f-81db-44df-8580-07e8ac1e62df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d91ae632-e1a2-4cdd-a84e-97572a377f1d");
        }
    }
}
