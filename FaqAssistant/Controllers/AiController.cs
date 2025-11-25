using Microsoft.AspNetCore.Mvc;

namespace FaqAssistant.Api.Controllers
{
    [ApiController]
    [Route("api/ai")]
    public class AiController : ControllerBase
    {
        private readonly OpenRouterAiService _ai;

        public AiController(OpenRouterAiService ai)
        {
            _ai = ai;
        }

        [HttpPost("suggest")]
        public async Task<IActionResult> Suggest([FromBody] Dictionary<string, string> body)
        {
            if (!body.ContainsKey("question"))
                return BadRequest(new { error = "question is required" });

            var question = body["question"];
            var answer = await _ai.SuggestAnswer(question);

            return Ok(new { draftAnswer = answer });
        }
    }
}
