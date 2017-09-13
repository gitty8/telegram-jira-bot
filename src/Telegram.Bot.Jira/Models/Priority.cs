// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System;
using Newtonsoft.Json;

namespace Telegram.Bot.Jira.Models
{
    public class Priority
    {
        [JsonProperty("iconUrl")]
        public Uri IconUri { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("self")]
        public Uri PriorityUri { get; set; }
    }
}