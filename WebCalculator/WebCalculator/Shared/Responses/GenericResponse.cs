namespace WebCalculator.Shared.Responses
{
    public class GenericResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public string OperationGuid { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
