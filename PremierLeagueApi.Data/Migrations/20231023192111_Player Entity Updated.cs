﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeagueApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlayerEntityUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");
        }
    }
}
