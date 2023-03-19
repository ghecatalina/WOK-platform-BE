namespace Application.Exceptions
{
    public class InvalidCredentialsException : ApplicationException
    {
        public InvalidCredentialsException() : base("Invalid credentials")
        { }
    }
}
