using Microsoft.AspNetCore.Mvc;
using OpenAI.Managers;
using OpenAI;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.ResponseModels;

namespace FinancialHealthChecker.Controllers
{
    public class ReportController : Controller
    {
        private readonly OpenAIService openAiService;

        public ReportController(OpenAIService openAIService)
        {
            this.openAiService = openAIService;
        }

        public async Task<IActionResult> Report()
        {
            var aiResponse = await getOpenAIResponse();
            var stringResponse = aiResponse.Choices.First().Text;
            ViewData["OpenAI"] = stringResponse;
            return View();
        }

        private async Task<CompletionCreateResponse> getOpenAIResponse()
        {
            var completionResult = await openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = "Explain quantum mechanics",
                Model = "gpt-3.5-turbo-instruct",
                MaxTokens = 250
            });

            return completionResult;
        }
    }
}
