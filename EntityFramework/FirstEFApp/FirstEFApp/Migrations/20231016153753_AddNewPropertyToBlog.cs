using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstEFApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPropertyToBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Blogs");
        }
    }
}
