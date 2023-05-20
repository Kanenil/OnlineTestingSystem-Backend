using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineTestingSystem.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedSlugfieldforAspNetUsersandtblCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "tblCourses",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "AspNetUsers",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourses_Slug",
                table: "tblCourses",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Slug",
                table: "AspNetUsers",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tblCourses_Slug",
                table: "tblCourses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Slug",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "tblCourses");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "AspNetUsers");
        }
    }
}
