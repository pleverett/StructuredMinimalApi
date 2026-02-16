using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chirper.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Posts_CreatedAtUtc",
                table: "Posts",
                column: "CreatedAtUtc",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId_CreatedAtUtc",
                table: "Posts",
                columns: new[] { "UserId", "CreatedAtUtc" },
                descending: new[] { false, true });

            migrationBuilder.CreateIndex(
                name: "IX_Follows_CreatedAtUtc",
                table: "Follows",
                column: "CreatedAtUtc");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CreatedAtUtc",
                table: "Comments",
                column: "CreatedAtUtc",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId_CreatedAtUtc",
                table: "Comments",
                columns: new[] { "PostId", "CreatedAtUtc" },
                descending: new[] { false, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_CreatedAtUtc",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Posts_UserId_CreatedAtUtc",
                table: "Posts");

            migrationBuilder.DropIndex(
                name: "IX_Follows_CreatedAtUtc",
                table: "Follows");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CreatedAtUtc",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PostId_CreatedAtUtc",
                table: "Comments");
        }
    }
}
