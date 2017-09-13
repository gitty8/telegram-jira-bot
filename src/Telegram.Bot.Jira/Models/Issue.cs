// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System;
using Newtonsoft.Json;
using Telegram.Bot.Jira.Converters;

namespace Telegram.Bot.Jira.Models
{
    public class Issue
    {
        [JsonProperty("fields")]
        [JsonConverter(typeof(IssueFieldJsonConverter))]
        public Fields Fields { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("self")]
        public Uri IssueUri { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }
    }
}