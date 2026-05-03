using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeague.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstHalfScore",
                table: "FootballMatches");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstHalfScore",
                table: "FootballMatches",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
