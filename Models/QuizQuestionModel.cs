namespace FinancialHealthChecker.Models
{
    public class QuizQuestionModel
    {
        public string Name { get; set; } = "What is your name?";
        public string Country { get; set; } = "In which country do you live?";
        public string FinancialGoals { get; set; } = "What are your key short-term and long-term financial goals?";
        public string IncomeStability { get; set; } = "What's your current income, and is it stable?";
        public string DebtDetails { get; set; } = "Do you have any debts? If so, what type and how much?";
        public string SavingsAmount { get; set; } = "How much do you save regularly, and how much is in your emergency fund?";
        public string InvestmentExperience { get; set; } = "What experience do you have with investments?";
        public string RiskTolerance { get; set; } = "Would you describe your risk tolerance as low, medium, or high?";
        public string InsuranceCoverage { get; set; } = "What insurance policies do you have?";
        public string RetirementPlans { get; set; } = "What are your retirement plans and expected retirement age?";
        public string FinancialChallenges { get; set; } = "Any specific financial challenges you're facing?";
        public string FinancialManagement { get; set; } = "How do you currently manage your finances?";
    }    

    
}
