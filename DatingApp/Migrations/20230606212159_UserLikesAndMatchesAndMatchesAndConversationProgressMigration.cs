using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatingApp.Migrations
{
    public partial class UserLikesAndMatchesAndMatchesAndConversationProgressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchesAndConversationProgress",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatchedUsersIds = table.Column<List<int>>(type: "integer[]", nullable: false),
                    ConversationLevel = table.Column<int>(type: "integer", nullable: false),
                    ActiveMatch = table.Column<bool>(type: "boolean", nullable: false),
                    DateOfMatch = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateOfLastInteraction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchesAndConversationProgress", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "UserLikesAndMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SentLikes = table.Column<List<int>>(type: "integer[]", nullable: false),
                    ReceivedLikes = table.Column<List<int>>(type: "integer[]", nullable: false),
                    Matches = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikesAndMatches", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchesAndConversationProgress");

            migrationBuilder.DropTable(
                name: "UserLikesAndMatches");
        }
    }
}
