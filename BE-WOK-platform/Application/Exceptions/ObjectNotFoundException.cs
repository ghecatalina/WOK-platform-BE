namespace Application.Exceptions
{
    public class ObjectNotFoundException : ApplicationException
    {
        public ObjectNotFoundException(string type, object id)
            : base($"Object of type {type} with id:{id} doesn't exist.")
        {

        }
    }
}
