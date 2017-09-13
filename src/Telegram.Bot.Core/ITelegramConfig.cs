// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

namespace Telegram.Bot.Core
{
    public interface ITelegramConfig
    {
        string Endpoint { get; set; }

        string Token { get; set; }

        string WebToken { get; set; }
    }
}