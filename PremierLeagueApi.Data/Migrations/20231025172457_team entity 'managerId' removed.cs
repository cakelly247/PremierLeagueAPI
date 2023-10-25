using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeagueApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class teamentitymanagerIdremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ManagerId",
                table: "Teams");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagerId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "City", "Losses", "ManagerId", "TeamName", "Wins" },
                values: new object[] { 1, "Nowhere", 0, 1, "UnassignedTeam", 0 });
        }
    }
}
