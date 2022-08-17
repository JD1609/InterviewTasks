using Newtonsoft.Json;

namespace WebCalculator.Server.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly ICalculationServiceInternal _calculationServiceInternal;
        private readonly ILogger<CalculationService> _logger;
        private readonly Guid Guid;

        #region Ctor
        public CalculationService(ICalculationServiceInternal calculationServiceInternal, ILogger<CalculationService> logger)
        {
            _calculationServiceInternal = calculationServiceInternal;
            _logger = logger;
            Guid = Guid.NewGuid();

            _logger.LogInformation($"Operation [{Guid}] started");
        }
        #endregion

        public async Task<GenericResponse<ExpressionResult>> CalculateExpression(string expression, bool round = false)
        {
            _logger.LogInformation($"Expression to calculate: {expression}; round: {round}");

            var response = new GenericResponse<ExpressionResult>()
            {
                OperationGuid = Guid.ToString()
            };


            try
            {
                var result = _calculationServiceInternal.CalculateExpression(expression, round);

                response.Data = result;

                await _calculationServiceInternal.SaveCalculatedExpression(result);

                _logger.LogInformation($"Operation successfull, response data:\n{JsonConvert.SerializeObject(result, Formatting.Indented)}");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message.StartsWith("Cannot find column") ? $"Unable to calculate expression: '{expression}'" : ex.Message;

                _logger.LogError(ex.ToString());
            }


            return response;
        }

        public async Task<GenericResponse<List<ExpressionResult>>> GetHistory(int resultCount = 10)
        {
            _logger.LogInformation("Request to get history");

            var response = new GenericResponse<List<ExpressionResult>>()
            {
                OperationGuid = Guid.ToString()
            };


            try
            {
                var data = await _calculationServiceInternal.GetHistory(resultCount);

                response.Data = data;

                _logger.LogInformation($"Operation successfull, response data:\n{JsonConvert.SerializeObject(data, Formatting.Indented)}");
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                _logger.LogError(ex.ToString());
            }


            return response;
        }
    }
}
