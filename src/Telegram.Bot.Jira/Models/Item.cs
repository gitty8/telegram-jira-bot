// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using Newtonsoft.Json;

namespace Telegram.Bot.Jira.Models
{
    public class Item
    {
        [JsonProperty("field")]
        public string Field { get; set; }

        [JsonProperty("fieldtype")]
        public string FieldType { get; set; }

        [JsonProperty("to")]
        public string New { get; set; }

        [JsonProperty("toString")]
        public string NewString { get; set; }

        [JsonProperty("from")]
        public string Old { get; set; }

        [JsonProperty("fromString")]
        public string OldString { get; set; }
    }
}