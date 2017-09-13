// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Threading.Tasks;

namespace Telegram.Bot.Jira
{
    public interface IJiraBotRepository
    {
        Task<long> GetChatId(string token);
        Task<string> GetOrCreateToken(long chatId);
    }
}