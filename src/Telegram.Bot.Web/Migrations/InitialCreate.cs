// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Telegram.Bot.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "JiraEntities",
                table => new
                {
                    Id = table.Column<Guid>("uniqueidentifier", nullable: false),
                    ChatId = table.Column<long>("bigint", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_JiraEntities", x => x.Id); });

            migrationBuilder.CreateIndex(
                "IX_JiraEntities_ChatId",
                "JiraEntities",
                "ChatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "JiraEntities");
        }
    }
}