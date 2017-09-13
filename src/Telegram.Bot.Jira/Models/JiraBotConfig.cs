// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using Telegram.Bot.Core;

namespace Telegram.Bot.Jira
{
    public class JiraBotConfig : ITelegramConfig
    {
        public JiraBotConfig()
        {
        }

        public JiraBotConfig(string token, string endpoint)
        {
            Token = token;
            Endpoint = endpoint;
        }

        public string JiraWebhookUrl { get; set; }

        public string Token { get; set; }

        public string Endpoint { get; set; }

        public string WebToken { get; set; }
    }
}