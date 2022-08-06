namespace WebCalculator.Server.Services.Internals.Interfaces
{
    public interface ICalculationServiceInternal
    {
        ExpressionResult CalculateExpression(string expression, bool round = false);
        void SaveCalculatedExpression(ExpressionResult expression);
        List<ExpressionResult> GetHistory(int resultCount = 10);
    }
}
