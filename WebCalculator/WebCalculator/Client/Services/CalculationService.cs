using System.Net.Http.Json;

namespace WebCalculator.Client.Services
{
    public class CalculationService : ICalculationService
    {
        private readonly HttpClient _http;

        #region Ctor
        public CalculationService(HttpClient http)
        {
            _http = http;
        }
        #endregion

        public async Task<ExpressionResult> CalculateExpression(string expression, bool round = false)
        {
            var request = new CalculateExpressionRequest 
            { 
                Expression = expression,
                Round = round
            };


            var response = await _http.PostAsJsonAsync("api/Calculation/calculate-expression", request);

            var calculatedResponse = await response.Content.ReadFromJsonAsync<GenericResponse<ExpressionResult>>();

            if (!calculatedResponse.Success)
                SendError(new Exception(calculatedResponse.Message));

            return calculatedResponse.Data;
        }

        public async Task<List<ExpressionResult>> GetHistory(int resultCount = 10)
        {
            var response = await _http.GetFromJsonAsync<GenericResponse<List<ExpressionResult>>>($"api/Calculation/get-history/{resultCount}");

            if (!response.Success)
                SendError(new Exception(response.Message));

            return response.Data;
        }

        private void SendError(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
