namespace Application.Exceptions.ExceptionModel
{
    public class CustomErrorResponse
    {
        public string? Type { get; set; }
        public string? Message { get; set; }
        public string? StackTrace { get; set; }

        public CustomErrorResponse(Exception? ex)
        {
            if (ex != null)
            {
                Type = ex.GetType().Name;
                Message = ex.Message;
                StackTrace = ex.ToString();
            }

        }

        public override string ToString()
        {
            return $"Type - {Type}, Message - {Message}, StackTrace - {StackTrace} ";
        }
    }
}
