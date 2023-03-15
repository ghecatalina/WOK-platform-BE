namespace Application.Exceptions
{
    public class InvalidDateTimeException : ApplicationException
    {
        public InvalidDateTimeException(DateTime date1)
            : base($"DateTime {date1} less than current time {DateTime.UtcNow}.")
        { }
    }
}
