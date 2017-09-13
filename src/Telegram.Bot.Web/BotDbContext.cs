// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Jira;

namespace Telegram.Bot.Web
{
    public class BotDbContext : DbContext, IJiraContext
    {
        public BotDbContext(DbContextOptions<BotDbContext> options) : base(options)
        {
        }

        public DbSet<JiraEntity> JiraEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JiraEntity>().HasIndex(x => x.ChatId);
        }
    }
}