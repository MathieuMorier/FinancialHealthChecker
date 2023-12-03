using Microsoft.AspNetCore.Mvc;
using OpenAI.Managers;
using OpenAI;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.Interfaces;
using OpenAI.ObjectModels.ResponseModels;
using FinancialHealthChecker.Models;


namespace FinancialHealthChecker.Controllers
{
    public class ReportController : Controller
    {
        private readonly OpenAIService openAiService;

        public ReportController(OpenAIService openAIService)
        {
            this.openAiService = openAIService;
        }

        public async Task<IActionResult> Report(QuizAnswerModel profile)
        {
            var aiResponse = await getOpenAIResponse(profile);
            TempData["OpenAI"] = aiResponse.Choices.First().Text;
            return View();
        }

        private async Task<CompletionCreateResponse> getOpenAIResponse(QuizAnswerModel profile)
        {
            var completionResult = await openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = 
                        $@"""Please format the response as HTML content enclosed in a Bootstrap 4 styled 'div' tag. Each 'div' should be a card component with a soft blue background, nice readable font, and overall user-friendly and aesthetically pleasing design. Here's an example of how each answer should be formatted
                        <div class='card' style='background-color: #f2f7ff; margin-bottom: 10px;'>
                            <div class='card-body'>
                                <h5 class='card-title'>title</h5>
                                <p class='card-text'>Response content here.</p>
                            </div>
                        </div> 

                            Give financial advice and guidance based on the following answerS to this questionnaire :

                            1. Financial Goals: {profile.FinancialGoals}
                            2. Income Stability: {profile.IncomeStability}
                            3. Debt Details: {profile.DebtDetails}
                            4. Savings Amount: {profile.SavingsAmount}
                            5. Investment Experience: {profile.InvestmentExperience}
                            6. Risk Tolerance: {profile.RiskTolerance}
                            7. Insurance Coverage: {profile.InsuranceCoverage}
                            8. Retirement Plans: {profile.RetirementPlans}
                            9. Financial Challenges: {profile.FinancialChallenges}
                            10. Financial Management: {profile.FinancialManagement}
                            11. My Name: {profile.Name}
                            12. My Country: {profile.Country}

                            Give practical example, links to financial tools to used, example of portfolio performance based on some savings, speak to the person using his name, give words of hope .
                            ",
                Model = "gpt-3.5-turbo-instruct",
                MaxTokens = 3500
            });

            return completionResult;
        }
    }
}
