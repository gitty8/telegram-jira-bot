// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telegram.Bot.Jira.Models
{
    public class Changelog
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("items")]
        public IEnumerable<Item> Items { get; set; }
    }
}