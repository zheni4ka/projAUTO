using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Vlad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id", "CompanyId", "Description", "ImgURL", "Mark", "Model", "Price", "Speed", "YearRelease" },
                values: new object[] { 6, 1, "The Mazda MX-5 is a lightweight two-passenger sports car manufactured and marketed by Mazda with a front mid-engine, rear-wheel-drive layout.", "https://th.bing.com/th/id/R.3955fc8345ee89788d13accf642e621c?rik=K6Rtq33E8xWtqw&pid=ImgRaw&r=0", "Mazda", "Miata", 9000, 190, 1989 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Autos",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
