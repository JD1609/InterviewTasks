using WebCalculator.Server.Data;

namespace WebCalculator.Server.Services.Internals
{
    public class CalculationServiceInternal : ICalculationServiceInternal
    {
        private readonly DataContext _context;
        private readonly ILogger<CalculationServiceInternal> _logger;

        #region Ctor
        public CalculationServiceInternal(DataContext context, ILogger<CalculationServiceInternal> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        public async Task<List<ExpressionResult>> GetHistory(int resultCount = 10)
        {
            return await _context.ExpressionResults
                            .OrderByDescending(er => er.CalculationTime)
                            .Take(resultCount)
                            .OrderBy(er => er.CalculationTime)
                            .ToListAsync();
        }

        public ExpressionResult CalculateExpression(string expression, bool round = false)
        {
            var dt = new System.Data.DataTable();
            var result = dt.Compute(expression, null).ToString();

            if (round && result != null)
                result = Math.Round(decimal.Parse(result)).ToString();

            var expressionResult = new ExpressionResult
            {
                Expression = expression,
                Result = result ?? throw new Exception($"Unable to calculate expression: '{expression}'")
            };

            return expressionResult;
        }

        public async Task<bool> SaveCalculatedExpression(ExpressionResult expression)
        {
            _context.ExpressionResults.Add(expression);
            await _context.SaveChangesAsync();

            return true; // Success
        }
    }
}
