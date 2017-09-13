// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System;

namespace Telegram.Bot.Jira
{
    public class JiraEntity
    {
        public long ChatId { get; set; }

        public Guid Id { get; set; }
    }
}