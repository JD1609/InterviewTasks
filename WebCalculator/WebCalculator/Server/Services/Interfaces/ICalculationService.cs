namespace WebCalculator.Server.Services.Interfaces
{
    public interface ICalculationService
    {
        GenericResponse<List<ExpressionResult>> GetHistory(int resultCount = 10);
        GenericResponse<ExpressionResult> CalculateExpression(string expression, bool round = false);
    }
}
