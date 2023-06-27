using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artisan.II.Data.EFCore.Migrations
{
    /// <inheritdoc />
    public partial class AddedFileContentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "UserFiles",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AvatarName",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AvatarName",
                table: "AspNetUsers",
                column: "AvatarName");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserFiles_AvatarName",
                table: "AspNetUsers",
                column: "AvatarName",
                principalTable: "UserFiles",
                principalColumn: "Name",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserFiles_AvatarName",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AvatarName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "UserFiles");

            migrationBuilder.DropColumn(
                name: "AvatarName",
                table: "AspNetUsers");
        }
    }
}
