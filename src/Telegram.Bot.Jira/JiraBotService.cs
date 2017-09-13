// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Telegram.Bot.Core;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Jira
{
    public class JiraBotService : IJiraBotService
    {
        private readonly IJiraBotClient _client;
        private readonly JiraBotConfig _config;
        private readonly IJiraBotRepository _repo;

        public JiraBotService(IJiraBotClient botClient, IJiraBotRepository repository,
            IOptions<JiraBotConfig> jiraConfig)
        {
            _client = botClient;
            _config = jiraConfig.Value;
            _repo = repository;
        }

        public async Task ParseUpdateAsync(Update update)
        {
            var msg = update.Message;
            if (msg.Type != MessageType.TextMessage) return;
            var botCommands = msg.Entities
                .Where(x => x.Type == MessageEntityType.BotCommand)
                .Select(x => FormatBotCommand(msg.Text.Substring(x.Offset, x.Length)))
                .Select(x => ProcessBotCommand(x, update.Message));
            await Task.WhenAll(botCommands);
        }

        public async Task<bool> IsValidEndpoint(string token)
        {
            var chatId = await _repo.GetChatId(token);
            return chatId != 0;
        }

        public async Task<Message> ProcessNotification(Models.Update update, string token, string projectKey,
            string issueKey)
        {
            var chatId = await _repo.GetChatId(token);
            var formatter = new HtmlBotMessageFormatter();
            var message = new JiraMessageBuilder(update, projectKey, issueKey, new HtmlBotMessageFormatter());
            return await _client.SendTextMessageAsync(chatId, message.Build(), formatter.ParseMode,
                disableWebPagePreview: true);
        }

        private async Task ProcessBotCommand(string command, Message message)
        {
            if (command == "start") await ProcessStartCommand(message);
        }

        private async Task ProcessStartCommand(Message message)
        {
            var chatId = message.Chat.Id;
            var token = await _repo.GetOrCreateToken(chatId);
            var text =
                "Hey, add the following Url to your Jira webhooks see the <a href=\"https://developer.atlassian.com/jiradev/jira-apis/webhooks#Webhooks-Registeringawebhook\">Jira Documentation</a> fore more information\n<b>Webhook Url:</b>\n" +
                _config.JiraWebhookUrl + "/" +
                token +
                "/${project.key}/${issue.key}";

            await _client.SendTextMessageAsync(chatId, text, ParseMode.Html, disableWebPagePreview: true);
        }

        private static string FormatBotCommand(string value)
        {
            var botCommand = value.TrimStart('/');
            var indexOfAt = botCommand.IndexOf(value: '@');
            if (indexOfAt != -1)
                botCommand = botCommand.Substring(startIndex: 0, length: botCommand.Length - indexOfAt);
            return botCommand;
        }
    }
}