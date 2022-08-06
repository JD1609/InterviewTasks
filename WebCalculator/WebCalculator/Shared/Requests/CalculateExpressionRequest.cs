namespace WebCalculator.Shared.Requests
{
    public class CalculateExpressionRequest
    {
        public string Expression { get; set; } = string.Empty;
        public bool Round { get; set; } = false;
    }
}
