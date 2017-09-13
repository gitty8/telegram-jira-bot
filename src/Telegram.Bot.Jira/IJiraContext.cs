// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using Microsoft.EntityFrameworkCore;

namespace Telegram.Bot.Jira
{
    public interface IJiraContext
    {
        DbSet<JiraEntity> JiraEntities { get; set; }
    }
}