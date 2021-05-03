using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class UserEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherSummaries_UserSearch_UserSearchId",
                table: "WeatherSummaries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSearch",
                table: "UserSearch");

            migrationBuilder.RenameTable(
                name: "UserSearch",
                newName: "UserSearches");

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "WeatherSummaries",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSearches",
                table: "UserSearches",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Key = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherSummaries_UserSearches_UserSearchId",
                table: "WeatherSummaries",
                column: "UserSearchId",
                principalTable: "UserSearches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeatherSummaries_UserSearches_UserSearchId",
                table: "WeatherSummaries");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSearches",
                table: "UserSearches");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "WeatherSummaries");

            migrationBuilder.RenameTable(
                name: "UserSearches",
                newName: "UserSearch");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSearch",
                table: "UserSearch",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeatherSummaries_UserSearch_UserSearchId",
                table: "WeatherSummaries",
                column: "UserSearchId",
                principalTable: "UserSearch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
