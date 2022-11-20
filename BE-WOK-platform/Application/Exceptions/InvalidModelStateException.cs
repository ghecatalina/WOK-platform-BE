using Application.Exceptions.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Application.Exceptions
{
    public class InvalidModelStateException : ApplicationException
    {
        private readonly ModelStateDictionary _modelState;
        public InvalidModelStateException(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }
        public override string ToString()
        {
            return _modelState.Errors();
        }
    }
}
