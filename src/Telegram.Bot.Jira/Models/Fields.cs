// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Telegram.Bot.Jira.Models
{
    public class Fields
    {
        [JsonProperty("assignee")]
        public User Assignee { get; set; }

        [JsonProperty("attachment")]
        public IEnumerable<Attachment> Attachments { get; set; }

        [JsonProperty("creator")]
        public User Creator { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("issuetype")]
        public IssueType IssueType { get; set; }

        public Dictionary<string, JToken> Other { get; set; } = new Dictionary<string, JToken>();

        [JsonProperty("priority")]
        public Priority Priority { get; set; }

        [JsonProperty("reporter")]
        public User Reporter { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }
    }
}