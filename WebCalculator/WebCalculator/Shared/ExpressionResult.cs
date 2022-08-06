using System.ComponentModel.DataAnnotations;

namespace WebCalculator.Shared
{
    public class ExpressionResult
    {
        [Key]
        public int Id { get; set; }
        public string Expression { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
        public DateTime CalculationTime { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Expression} = {Result}";
        }
    }
}
