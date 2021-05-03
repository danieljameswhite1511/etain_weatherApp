using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class WeatherEnitities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProductBrands");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.CreateTable(
                name: "UserSearch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Query = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSearch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeatherSummaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserSearchId = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    LocationType = table.Column<string>(type: "TEXT", nullable: true),
                    WoeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LatitudeLongitude = table.Column<string>(type: "TEXT", nullable: true),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: true),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    SunRise = table.Column<string>(type: "TEXT", nullable: true),
                    SunSet = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherSummaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherSummaries_UserSearch_UserSearchId",
                        column: x => x.UserSearchId,
                        principalTable: "UserSearch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocationSearchResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherSummaryId = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    LocationType = table.Column<string>(type: "TEXT", nullable: true),
                    WoeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LatLong = table.Column<string>(type: "TEXT", nullable: true),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationSearchResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationSearchResults_WeatherSummaries_WeatherSummaryId",
                        column: x => x.WeatherSummaryId,
                        principalTable: "WeatherSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WeatherSummaryId = table.Column<int>(type: "INTEGER", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Slug = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CrawlRate = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sources_WeatherSummaries_WeatherSummaryId",
                        column: x => x.WeatherSummaryId,
                        principalTable: "WeatherSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExternalSystemId = table.Column<long>(type: "INTEGER", nullable: false),
                    WeatherSummaryId = table.Column<int>(type: "INTEGER", nullable: true),
                    WeatherStateImageUrl = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherStateName = table.Column<string>(type: "TEXT", nullable: true),
                    WeatherStateAbbr = table.Column<string>(type: "TEXT", nullable: true),
                    WindDirectionCompass = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ApplicableDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MinTemp = table.Column<decimal>(type: "TEXT", nullable: true),
                    MaxTemp = table.Column<decimal>(type: "TEXT", nullable: true),
                    TheTemp = table.Column<decimal>(type: "TEXT", nullable: true),
                    WindSpeed = table.Column<decimal>(type: "TEXT", nullable: true),
                    WindDirection = table.Column<decimal>(type: "TEXT", nullable: true),
                    AirPressure = table.Column<decimal>(type: "TEXT", nullable: true),
                    Humidity = table.Column<int>(type: "INTEGER", nullable: true),
                    Visibility = table.Column<decimal>(type: "TEXT", nullable: true),
                    Predictability = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_WeatherSummaries_WeatherSummaryId",
                        column: x => x.WeatherSummaryId,
                        principalTable: "WeatherSummaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationSearchResults_WeatherSummaryId",
                table: "LocationSearchResults",
                column: "WeatherSummaryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sources_WeatherSummaryId",
                table: "Sources",
                column: "WeatherSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_WeatherSummaryId",
                table: "Weather",
                column: "WeatherSummaryId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherSummaries_UserSearchId",
                table: "WeatherSummaries",
                column: "UserSearchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationSearchResults");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "WeatherSummaries");

            migrationBuilder.DropTable(
                name: "UserSearch");

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Name = table.Column<string>(type: "decimal(18,2)", maxLength: 255, nullable: false),
                    PictureUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    ProductBrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");
        }
    }
}
