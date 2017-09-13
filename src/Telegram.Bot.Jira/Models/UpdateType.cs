// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

namespace Telegram.Bot.Jira.Models
{
    public enum UpdateType
    {
        None,
        IssueCreated,
        IssueChanged,
        IssueDeleted,
        CommentCreated,
        CommentUpdated,
        CommentDeleted
    }
}