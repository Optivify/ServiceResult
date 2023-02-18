namespace Optivify.ServiceResult.AspNetCore
{
    public class ResultApiModel
    {
        public bool Success { get; set; }

        public object? Message { get; set; }

        public object? Value { get; set; }
    }
}
