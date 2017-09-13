// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Threading.Tasks;
using Telegram.Bot.Core;
using Telegram.Bot.Types;
using Update = Telegram.Bot.Jira.Models.Update;

namespace Telegram.Bot.Jira
{
    public interface IJiraBotService : ITelegramBotService
    {
        Task<bool> IsValidEndpoint(string token);
        Task<Message> ProcessNotification(Update update, string token, string projectKey, string issueKey);
    }
}