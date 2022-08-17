namespace WebCalculator.Server.Services.Internals.Interfaces
{
    public interface ICalculationServiceInternal
    {
        ExpressionResult CalculateExpression(string expression, bool round = false);
        Task<bool> SaveCalculatedExpression(ExpressionResult expression);
        Task<List<ExpressionResult>> GetHistory(int resultCount = 10);
    }
}
