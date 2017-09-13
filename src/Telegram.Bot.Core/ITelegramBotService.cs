// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace Telegram.Bot.Core
{
    public interface ITelegramBotService
    {
        Task ParseUpdateAsync(Update update);
    }
}