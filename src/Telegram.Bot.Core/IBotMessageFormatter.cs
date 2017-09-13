// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Core
{
    public interface IBotMessageFormatter
    {
        string BlockCodeEnd { get; }
        string BlockCodeStart { get; }
        string BoldEnd { get; }

        string BoldStart { get; }
        string ItalicEnd { get; }
        string ItalicStart { get; }
        string LineSeperator { get; }
        ParseMode ParseMode { get; }
        string Escape(string message);
        string FormatLink(string linkTarget, string linkText);
        string FormatBold(string message);
        string FormatItalic(string message);
        string FormatInlineCode(string message);
        string FormatBlockCode(string message);
        string FormatMention(int userId, string linkText);
    }
}