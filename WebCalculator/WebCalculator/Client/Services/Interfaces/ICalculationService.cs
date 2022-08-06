namespace WebCalculator.Client.Services.Interfaces
{
    public interface ICalculationService
    {
        Task<List<ExpressionResult>> GetHistory(int resultCount = 10);
         Task<ExpressionResult> CalculateExpression(string expression, bool round = false);
    }
}
