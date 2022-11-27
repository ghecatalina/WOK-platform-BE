namespace Application.Exceptions
{
    public class ObjectNotFoundException : ApplicationException
    {
        public ObjectNotFoundException(string type, object id)
            : base($"Object of type {type} with id:{id} doesn't exist.")
        {

        }

        public ObjectNotFoundException(string type, string key, object value)
            : base($"Object of type {type} with {key}:{value} doesn't exist.")
        {

        }

        public ObjectNotFoundException(string type)
            : base($"Object of type {type} doesn't exist.")
        {

        }

        public ObjectNotFoundException(string type, params (string key, object value)[] keyFields)
            : base($"Object of type {type} with {string.Join(" and ", keyFields.Select(p => $"{p.key}:{p.value}"))} doesn't exist.")
        {

        }
    }
}
