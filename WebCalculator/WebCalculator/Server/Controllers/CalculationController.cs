using Microsoft.AspNetCore.Mvc;
using WebCalculator.Shared.Requests;

namespace WebCalculator.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService _calculationService;

        public CalculationController(ICalculationService calculationService)
        {
            _calculationService = calculationService;
        }


        [HttpGet("get-history/{resultCount}")]
        public async Task<ActionResult<GenericResponse<List<ExpressionResult>>>> GetHistory(int resultCount = 10)
        {
            resultCount = resultCount > 100 ? 100 : resultCount;

            var response = await Task.Run(() => _calculationService.GetHistory(resultCount));

            return Ok(response);
        }

        [HttpPost("calculate-expression")]
        public async Task<ActionResult<GenericResponse<ExpressionResult>>> CalculateExpression(CalculateExpressionRequest request)
        {
            if (string.IsNullOrEmpty(request.Expression))
                return BadRequest(new GenericResponse<ExpressionResult>
                {
                    Success = false,
                    Message = "Request expression can not be null."
                });


            var response = await Task.Run(() => _calculationService.CalculateExpression(request.Expression, request.Round));

            return Ok(response);
        }
    }
}
