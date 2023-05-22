using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace OnlineTestingSystem.Presistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveprimarykeytoUserIdandCourseIdintblCourseUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCourseUsers",
                table: "tblCourseUsers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "tblCourseUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCourseUsers",
                table: "tblCourseUsers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourseUsers_UserId",
                table: "tblCourseUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCourseUsers",
                table: "tblCourseUsers");

            migrationBuilder.DropIndex(
                name: "IX_tblCourseUsers_UserId",
                table: "tblCourseUsers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tblCourseUsers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCourseUsers",
                table: "tblCourseUsers",
                columns: new[] { "UserId", "CourseId" });
        }
    }
}
