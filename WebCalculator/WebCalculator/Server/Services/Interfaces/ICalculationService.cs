namespace WebCalculator.Server.Services.Interfaces
{
    public interface ICalculationService
    {
        Task<GenericResponse<List<ExpressionResult>>> GetHistory(int resultCount = 10);
        Task<GenericResponse<ExpressionResult>> CalculateExpression(string expression, bool round = false);
    }
}
