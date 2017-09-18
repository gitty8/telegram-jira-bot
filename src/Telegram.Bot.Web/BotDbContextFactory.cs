// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Telegram.Bot.Web
{
    public class BotDbContextFactory : IDesignTimeDbContextFactory<BotDbContext>
    {
        public BotDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            var builder = new DbContextOptionsBuilder<BotDbContext>();
            var connectionstring = configuration.GetConnectionString("TelegramSQLConnection");
            builder.UseSqlServer(connectionstring);
            return new BotDbContext(builder.Options);
        }
    }
}