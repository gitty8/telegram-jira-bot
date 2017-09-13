// Copyright (c) 2017 Fluffy Fairy Games
// Distributed under the MIT License.
// https://github.com/FluffyFairyGames/telegram-jira-bot/blob/master/LICENSE

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Telegram.Bot.Jira;
using Telegram.Bot.Types;

namespace Telegram.Bot.Web.Controllers
{
    [Route("api/[controller]")]
    public class JiraBotController : Controller
    {
        private readonly IJiraBotService _jiraBot;
        private readonly string _jiraToken;

        public JiraBotController(IJiraBotService jiraBotService, IOptions<JiraBotConfig> config)
        {
            _jiraBot = jiraBotService;
            _jiraToken = config.Value.WebToken;
        }

        public IActionResult Index()
        {
            return Ok("JiraBot");
        }

        [HttpPost]
        [Route("[action]/{token}")]
        public async Task<IActionResult> Update(string token, [FromBody] Update update)
        {
            if (token != _jiraToken)
                return Forbid();

            await _jiraBot.ParseUpdateAsync(update);
            return Ok();
        }

        [HttpPost]
        [Route("[action]/{token}/{projectKey}/{issueKey}")]
        public async Task<IActionResult> Webhook(string token, string projectKey, string issueKey,
            [FromBody] JToken jToken)
        {
            if (!await _jiraBot.IsValidEndpoint(token))
                return NotFound();


            var update = jToken.ToObject<Jira.Models.Update>();

            await _jiraBot.ProcessNotification(update, token, projectKey, issueKey);
            return Ok();
        }
    }
}