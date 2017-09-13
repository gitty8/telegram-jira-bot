// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Options;

namespace Telegram.Bot.Jira
{
    public class JiraBotClient : TelegramBotClient, IJiraBotClient
    {
        public JiraBotClient(IOptions<JiraBotConfig> config) : this(config.Value.Token, config.Value.Endpoint)
        {
        }

        public JiraBotClient(string token, string webhookEndpoint, HttpClient httpClient = null) : base(token,
            httpClient)
        {
            SetWebhookAsync(webhookEndpoint).Wait();
        }

        public JiraBotClient(string token, string webhookEndpoint, IWebProxy webProxy) : base(token, webProxy)
        {
            SetWebhookAsync(webhookEndpoint).Wait();
        }
    }
}