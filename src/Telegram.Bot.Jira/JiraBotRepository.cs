// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Telegram.Bot.Jira
{
    public class JiraBotRepository<T> : IJiraBotRepository where T : DbContext, IJiraContext
    {
        private readonly T _ctx;

        public JiraBotRepository(T ctx)
        {
            _ctx = ctx;
        }

        public async Task<long> GetChatId(string token)
        {
            var jiraEntity = await _ctx.JiraEntities.FindAsync(Guid.Parse(token));
            return jiraEntity == null ? default(long) : jiraEntity.ChatId;
        }

        public async Task<string> GetOrCreateToken(long chatId)
        {
            var jiraEntity = await _ctx.JiraEntities.FirstOrDefaultAsync(x => x.ChatId == chatId);
            if (jiraEntity != null) return jiraEntity.Id.ToString();
            jiraEntity = new JiraEntity {ChatId = chatId};
            await _ctx.JiraEntities.AddAsync(jiraEntity);
            await _ctx.SaveChangesAsync();
            return jiraEntity.Id.ToString();
        }
    }
}