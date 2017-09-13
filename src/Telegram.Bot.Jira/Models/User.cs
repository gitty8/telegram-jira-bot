// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Telegram.Bot.Jira.Models
{
    public class User
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("avatarUrls")]
        public Dictionary<string, Uri> AvatarUris { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("emailAddress")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("self")]
        public Uri UserUri { get; set; }
    }
}