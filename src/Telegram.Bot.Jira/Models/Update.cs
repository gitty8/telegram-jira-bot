// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using Newtonsoft.Json;

namespace Telegram.Bot.Jira.Models
{
    public class Update
    {
        private int _updateType = -1;

        [JsonProperty("Changelog")]
        public Changelog Changelog { get; set; }

        [JsonProperty("comment")]
        public Comment Comment { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Issue")]
        public Issue Issue { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }

        [JsonIgnore]
        public UpdateType Type
        {
            get
            {
                if (_updateType != -1)
                    return (UpdateType) _updateType;
                var webhookEvent = WebhookEvent;
                _updateType = webhookEvent == "jira:issue_created"
                    ? 1
                    : (webhookEvent == "jira:issue_updated"
                        ? 2
                        : (webhookEvent == "jira:issue_deleted"
                            ? 3
                            : (webhookEvent == "comment_created"
                                ? 4
                                : (webhookEvent == "comment_updated"
                                    ? 5
                                    : (webhookEvent == "comment_deleted" ? 6 : 0)))));
                return (UpdateType) _updateType;
            }
        }

        [JsonProperty("User")]
        public User User { get; set; }

        [JsonProperty("webhookEvent")]
        public string WebhookEvent { get; set; }
    }
}