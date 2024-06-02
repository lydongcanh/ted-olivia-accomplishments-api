using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TedOliviaAccomplishmentsApi.Core.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class SaveOwnerAsString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "owner",
                table: "accomplishments",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "owner",
                table: "accomplishments",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
