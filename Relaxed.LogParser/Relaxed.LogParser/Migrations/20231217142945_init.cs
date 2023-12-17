using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Relaxed.LogParser.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    BattleEyeId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SteamId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DayzId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    StatisticsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatisticsType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    DateWritten = table.Column<DateTime>(type: "datetime", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticsId);
                });

            migrationBuilder.CreateTable(
                name: "Territory",
                columns: table => new
                {
                    TerritoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerPlayerId = table.Column<int>(type: "int", nullable: true),
                    OwnerDayzId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PosX = table.Column<int>(type: "int", nullable: false),
                    PosY = table.Column<int>(type: "int", nullable: false),
                    PosZ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastFound = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Territory", x => x.TerritoryId);
                });

            migrationBuilder.CreateTable(
                name: "TerritoryMember",
                columns: table => new
                {
                    TerritoryMemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerritoryId = table.Column<int>(type: "int", nullable: false),
                    MemberPlayerId = table.Column<int>(type: "int", nullable: true),
                    MemberDayzId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LastFound = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerritoryMember", x => x.TerritoryMemberId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Territory");

            migrationBuilder.DropTable(
                name: "TerritoryMember");
        }
    }
}
